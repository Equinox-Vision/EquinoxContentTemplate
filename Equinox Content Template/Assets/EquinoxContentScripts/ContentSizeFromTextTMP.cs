using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ContentSizeFromTextTMP : MonoBehaviour
{
    public float PaddingHeight;

    private float oldHeight;
    private TextMeshProUGUI tmp;
    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        var r = tmp.GetPixelAdjustedRect();
        if (r.height != oldHeight)
        {
            var sd = rt.sizeDelta;
            sd.y = r.height + PaddingHeight;
            rt.sizeDelta = sd;

            oldHeight = r.height;
            //Debug.Log($"height: {r.height}");
        }
    }
}
