using Animals.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace Animals.Spawner.Model
{
    [Serializable]
    public class SpawnerData : ISpawnerData
    {
        private readonly float _minCooldown;
        private readonly float _maxCooldown;
        private readonly float _spawnRadious;

        private readonly ObservableCollection<IDespawnable> _spawnedComponents;
        private readonly ObservableCollection<IDespawnable> _despawnedComponents;

        public ObservableCollection<IDespawnable> SpawnedComponents => _spawnedComponents;
        public ObservableCollection<IDespawnable> DespawnedComponents => _despawnedComponents;

        public float MinCooldown => _minCooldown;
        public float MaxCooldown => _maxCooldown;
        public float SpawnRadious => _spawnRadious;

        public SpawnerData(ISpawnerInitData initData)
        {
            _minCooldown = initData.MinCooldown;
            _maxCooldown = initData.MaxCooldown;
            _spawnRadious = initData.SpawnRadious;
            _spawnedComponents = new();
            _despawnedComponents = new();
        }
    }
}