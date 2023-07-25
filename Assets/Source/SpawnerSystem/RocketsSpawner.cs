using System;
using System.Collections.Generic;
using MovementSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnerSystem
{
    internal sealed class RocketsSpawner : Pool<RocketView.RocketView>
    {
        [SerializeField] private RocketView.RocketView _rocketView;
        [SerializeField] private int _delay;
        [SerializeField] private Transform _target;
        [SerializeField] private int _count;
        [SerializeField] private float _rocketSpeed;
        [SerializeField] private Material[] _materials;
        [SerializeField] private List<Transform> _spawnPoints;
        
        private float _timeAfterLastRocketSpawned;

        private void Start()
        {
            for (var i = 0; i < _count; i++)
                CreateObject(_rocketView, transform.position);
            
            InitRockets();
        }

        private void Update()
        {
            _timeAfterLastRocketSpawned += Time.deltaTime;

            if (_timeAfterLastRocketSpawned < _delay)
                return;
            
            if (TryGetObject(out var rocketView) == false)
                return;

            _timeAfterLastRocketSpawned = 0;
            SetRocket(rocketView);
        }

        private void InitRockets()
        {
            var rocketViews = GetObjects();

            foreach (var rocketView in rocketViews)
            {
                var movable = new Movement(_rocketSpeed);
                var position = _target.position;
                var target = new System.Numerics.Vector3(position.x, position.y, position.z);

                rocketView.Init(target, movable);
            }
        }

        private void SetRocket<T>(T rocketView) where T : MonoBehaviour
        {
            if (rocketView == null)
                throw new ArgumentNullException();

            if (rocketView.TryGetComponent(out MeshRenderer meshRenderer) == false)
                throw new ArgumentNullException();

            meshRenderer.material = _materials[Random.Range(0, _materials.Length)];
            rocketView.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            
            rocketView.gameObject.SetActive(true);
        }
    }
}