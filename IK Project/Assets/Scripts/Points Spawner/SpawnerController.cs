using System;
using System.Collections;
using UnityEngine;

namespace Points_Spawner
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay;
        [SerializeField] private Transform _pointPrefab;
        
        private void Start()
        {
            StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            yield return new WaitForSeconds(_spawnDelay);
            Spawn();
            StartCoroutine(Spawning());
        }

        private void Spawn()
        {
            var newPoint = Instantiate(_pointPrefab, transform.position, Quaternion.identity);
            PointsManager.Instance.AddPoint(newPoint);
        }
    }
}
