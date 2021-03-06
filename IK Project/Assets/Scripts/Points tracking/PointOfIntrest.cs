using System;
using System.Collections.Generic;
using IK;
using UnityEditor.UIElements;
using UnityEngine;

namespace Points_tracking
{
    public class PointOfIntrest : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points = new List<Transform>();
        [SerializeField] private float _rangeOfView;
        [SerializeField] private IKBase _ik;


        void Update()
        {
            SearchTheNearestPoint();
        }

        private void SearchTheNearestPoint()
        {
            if(_points.Count < 1)
                return;
            
            var theShortestDistance = Mathf.Infinity;

            foreach(var point in _points)
            {
                var distanceFromObject = Vector3.Distance(transform.position, point.transform.position);
                
                if (distanceFromObject < theShortestDistance)
                {
                    if (distanceFromObject < _rangeOfView)
                    {
                        _ik.Target = point;
                        theShortestDistance = distanceFromObject;
                    }
                    else
                        _ik.Target = null;
                }
            }
        }
    }
}
