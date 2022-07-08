using System;
using System.Collections;
using System.Collections.Generic;
using Parts;
using UnityEngine;

public class IKBase : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _smoothTargetPosition;
    [SerializeField]private float _smoothTime;
    
    [Header("Parts of body")]
    [SerializeField] private PartData _head;
    [SerializeField] private PartData _neck;
    [SerializeField] private PartData[] _spines;
    

    void LateUpdate()
    {
        
        LookAt(_head, _smoothTargetPosition);

        LookAt(_neck, _smoothTargetPosition);
        LookAt(_spines[0], _smoothTargetPosition);
    }

    private void Update()
    {
        _smoothTargetPosition = Vector3.Lerp(_smoothTargetPosition, _target.position, _smoothTime);
    }


    private void ClampAngle(PartData part)
    {
        var eulerAngles = part.tranformPart.eulerAngles;

        if (part.xAxis.isActive)
        {
            if (part.xAxis.limitAxis)
                eulerAngles.x = AnglesBehaviour.Clamp(eulerAngles.x, part.xAxis.min, part.xAxis.max);
        }
        else
            eulerAngles.x = 0;
        

        if (part.yAxis.isActive)
        {
            if (part.yAxis.limitAxis)
                eulerAngles.y = AnglesBehaviour.Clamp(eulerAngles.y, part.yAxis.min, part.yAxis.max);
        }
        else
            eulerAngles.y = 0;

        part.tranformPart.rotation = Quaternion.Euler(eulerAngles);
    }
    
    private void LookAt(PartData part, Vector3 target)  
    {
        var diff = target - part.tranformPart.position;

        part.tranformPart.rotation = Quaternion.LookRotation(diff);
        ClampAngle(part);
    }
    
}
