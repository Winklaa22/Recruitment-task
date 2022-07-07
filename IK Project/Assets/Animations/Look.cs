using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] private Transform loook;
    [SerializeField] private Animator _animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     transform.LookAt(loook);
    // }


    private void OnAnimatorIK(int layerIndex)
    {
        _animator.SetLookAtPosition(loook.position);
        _animator.SetLookAtWeight(1);
    }
}
