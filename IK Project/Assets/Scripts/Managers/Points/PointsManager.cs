using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;
    
    [SerializeField] private List<Transform> _pointsOfIntrest;
    
    public List<Transform> PointsOfIntrest
    {
        get
        {
            return _pointsOfIntrest;
        }
    }

    public delegate void OnUpdatePoints();
    public event OnUpdatePoints Entity_OnUpdatePoints;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoint(Transform point)
    {
        _pointsOfIntrest.Add(point);
        Entity_OnUpdatePoints?.Invoke();
    }

    public void RemovePoint(Transform point)
    {
        _pointsOfIntrest.Remove(point);
        Entity_OnUpdatePoints?.Invoke();
    }
}
