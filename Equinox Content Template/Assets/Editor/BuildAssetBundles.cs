using UnityEditor;
using UnityEngine;
using System.IO;

public class BuildAssetBundles
{
    private const string assetBundleDirectory = "../Builds/Assets"; // the default one
    private const string iOSAssetBundleDirectory = "../Builds/Assets/iOS"; // the special one for iOS. Curse on Apple for removing OpenGLES.
    [MenuItem("Assets/Build All Asset Bundles")]
    static void BuildAllAssetBundles()
    {
        var cwd = Directory.GetCurrentDirectory();
        Debug.Log("Current working directory: " + cwd);

        checkDirs();

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            var buildIOS = EditorUtility.DisplayDialog("Also build for iOS?", "Building iOS bundles could last HOURS. Are you really sure you want to do it?", "Yes", "No");
            buildAllAndroid();
            if (buildIOS)
            {
                buildAllIOS();
            }
        }
        else if (Application.platform == RuntimePlatform.OSXEditor)
        {
            var buildAndroid = EditorUtility.DisplayDialog("Also build for Android?", "Building Android bundles could last HOURS. Are you really sure you want to do it?", "Yes", "No");
            buildAllIOS();
            if (buildAndroid)
            {
                buildAllAndroid();
            }
        }
    }

    private static void checkDirs()
    {
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        if (!Directory.Exists(iOSAssetBundleDirectory))
        {
            Directory.CreateDirectory(iOSAssetBundleDirectory);
        }
    }

    private static void buildAllAndroid()
    {
        var res = BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                                        BuildAssetBundleOptions.ForceRebuildAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.AssetBundleStripUnityVersion,
                                        BuildTarget.Android);

        if (res == null || res.GetAllAssetBundles().Length == 0)
        {
            Debug.LogError("Something bad happened during Android Asset Bundle build");
            return;
        }
    }

    private static void buildAllIOS()
    {
        var res = BuildPipeline.BuildAssetBundles(iOSAssetBundleDirectory,
                                        BuildAssetBundleOptions.ForceRebuildAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.AssetBundleStripUnityVersion,
                                        BuildTarget.iOS);
        if (res == null || res.GetAllAssetBundles().Length == 0)
        {
            Debug.LogError("Something bad happened during iOS Asset Bundle build");
            return;
        }
    }

    private static void BuildOneAssetBundle(string name)
    {
        checkDirs();

        var assetPaths = AssetDatabase.GetAssetPathsFromAssetBundle(name + ".content");
        var build = new AssetBundleBuild();
        build.assetBundleName = name;
        build.assetNames = assetPaths;
        build.assetBundleVariant = "content";

        // Let's assume that building individual ab's doesnt last as long
        var res = BuildPipeline.BuildAssetBundles(assetBundleDirectory, new AssetBundleBuild[] { build },
            BuildAssetBundleOptions.ForceRebuildAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.AssetBundleStripUnityVersion,
            BuildTarget.Android);
        if (res == null || res.GetAllAssetBundles().Length == 0)
        {
            Debug.LogError("Something bad happened during Android Asset Bundle build");
            return;
        }
        res = BuildPipeline.BuildAssetBundles(iOSAssetBundleDirectory, new AssetBundleBuild[] { build },
            BuildAssetBundleOptions.ForceRebuildAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.AssetBundleStripUnityVersion,
            BuildTarget.iOS);
        if (res == null || res.GetAllAssetBundles().Length == 0)
        {
            Debug.LogError("Something bad happened during iOS Asset Bundle build");
            return;
        }
    }

}
