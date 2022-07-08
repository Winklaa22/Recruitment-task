using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglesBehaviour
{
    private static float GetCorrectValues(float value)
    {
        while (value > 360)
            value -= 360;
        while (value < 0)
            value += 360;
        
        if (value > 180)
            value -= 360;
        else if (value < -180)
            value += 360;

        return value;
    }
    
    public static float Clamp(float angle, float min, float max)
    {
        angle = GetCorrectValues(angle);

        min = GetCorrectValues(min);

        max = GetCorrectValues(max);
        
        return Mathf.Clamp(angle, min, max);
    }
}
