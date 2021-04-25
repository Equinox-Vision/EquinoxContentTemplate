using UnityEngine;

namespace EquinoxEngine.Core.Scriptables
{
    [CreateAssetMenu(fileName = "New Point of Interest type", menuName ="Equinox/Point of Interest Type")]
    public class PoiTypeTemplate : ScriptableObject
    {
        public string poiTypeName;
        public Sprite Icon;
        public GameObject assignedPrefab;
        public int poiType;
        public int poiSubtype;
        public float interactionMenuY = 1.7f;
        public float interactionMenuRadius = 0.2f;
        public bool showInteractionMenuOnProximity = true;
        public float dialogMenuRadius = 1f;
        public bool hasFace = true;
        public bool respectsUserFacingHacks = true;
        public bool wantsRandomAngleIf0 = true;
        public bool userPublishable = true;
        public bool castsBlobShadow = true;
        public int mininumAppVersion = 100;
    }
}