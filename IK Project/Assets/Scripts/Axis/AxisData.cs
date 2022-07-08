using UnityEngine;

namespace Axis
{
    [System.Serializable]
    public class AxisData
    {
        public bool isActive = true;
    
        [Header("Limit")]
        public bool limitAxis;
        public float min, max;
    }
}
