using Angles;
using Bones;
using Points_tracking;
using UnityEngine;

public class IKBase : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public Transform Target
    {
        set
        {
            _target = value;
        }
    }
    
    [SerializeField, Range(0, 1)] private float _weight;
    
    [Header("Smooth")]
    [SerializeField]private float _smoothTime;
    private Vector3 _smoothTargetPosition;
    
    
    [Header("Parts of body")]
    [SerializeField] private BoneData[] _bones;
    
    
    private void Update()
    {
        if (_target != null) 
            _smoothTargetPosition = Vector3.Lerp(_smoothTargetPosition, _target.position, _smoothTime);
    }
    
    void LateUpdate()
    {
        LookAtAll();
    }

    private void LookAtAll()
    {
        foreach (var bone in _bones)
        {
            if(_target != null)
                LookAt(bone, _smoothTargetPosition - bone.positionOffset);
            else
                bone.tranformPart.rotation = Quaternion.identity;
        }
    }
    
    private void ConfigAngle(BoneData bone)
    {
        var eulerAngles = bone.tranformPart.eulerAngles;

        if (bone.xAxis.isActive)
        {
            if (bone.xAxis.limitAxis)
                eulerAngles.x = AnglesBehaviour.Clamp(eulerAngles.x, bone.xAxis.min, bone.xAxis.max) * _weight;
        }
        else
            eulerAngles.x = 0;
        
        if (bone.yAxis.isActive)
        {
            if (bone.yAxis.limitAxis)
                eulerAngles.y = AnglesBehaviour.Clamp(eulerAngles.y, bone.yAxis.min, bone.yAxis.max) * _weight;
        }
        else
            eulerAngles.y = 0;

        bone.tranformPart.rotation = Quaternion.Euler(eulerAngles);
    }
    
    private void LookAt(BoneData bone, Vector3 target)  
    {
        var diff = target - bone.tranformPart.position;
        
        bone.tranformPart.rotation = Quaternion.LookRotation(diff);
        ConfigAngle(bone);
    }
    
}
