using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Axis
{
    public bool isActive = true;
    
    [Header("Limit")]
    public bool limitAxis;
    public float min, max;
}
