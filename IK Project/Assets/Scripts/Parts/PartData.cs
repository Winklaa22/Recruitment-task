using Parts.Type;
using UnityEngine;

namespace Parts
{
    [System.Serializable]
    public class PartData
    {
        [Header("Tranform")]
        public Transform tranformPart;

        [Header("Config")]
        [Range(0, 1)] public float _weight;

        [Header("Offset")]
        public Vector3 positionOffset;
        public float rotationOffset;

        [Header("Axises")]
        public Axis yAxis;
        public Axis xAxis;
    }
}
