using Animals.Components;
using System;
using System.Collections.ObjectModel;
using UnityEngine;
using Zenject;

namespace Animals.Spawner.Model
{
    [Serializable]
    public class SpawnerData : ISpawnerData
    {
        private readonly float _minCooldown;
        private readonly float _maxCooldown;
        private readonly float _spawnRadious;

        private readonly ObservableCollection<IPoolable<Vector3, IMemoryPool>> _spawnedComponents;
        public ObservableCollection<IPoolable<Vector3, IMemoryPool>> SpawnedComponents { get => _spawnedComponents; }

        public float MinCooldown => _minCooldown;
        public float MaxCooldown => _maxCooldown;
        public float SpawnRadious => _spawnRadious;

        public SpawnerData(ISpawnerInitData initData)
        {
            _minCooldown = initData.MinCooldown;
            _maxCooldown = initData.MaxCooldown;
            _spawnRadious = initData.SpawnRadious;
            _spawnedComponents = new();
        }
    }
}