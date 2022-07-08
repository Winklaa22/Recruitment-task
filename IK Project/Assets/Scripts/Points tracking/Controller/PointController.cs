using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _timeToKill;

    private void Start()
    {
        StartCoroutine(WaitToKill());
    }

    void Update()
    {
        transform.Translate(Vector3.left * _movementSpeed * Time.deltaTime, Space.World);
    }

    private IEnumerator WaitToKill()
    {
        yield return new WaitForSeconds(_timeToKill);
        PointsManager.Instance.RemovePoint(transform);
        Destroy(gameObject);
    }
}
