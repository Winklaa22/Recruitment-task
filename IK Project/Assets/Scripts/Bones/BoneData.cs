using Axis;
using UnityEngine;

namespace Bones
{
    [System.Serializable]
    public class BoneData
    {
        [SerializeField] private string name;
        
        [Header("Tranform")]
        public Transform tranformPart;

        [Header("Offset")]
        public Vector3 positionOffset;

        [Header("Axises")]
        public AxisData yAxis;
        public AxisData xAxis;
    }
}
