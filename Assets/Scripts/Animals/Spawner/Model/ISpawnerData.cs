using System.Collections.ObjectModel;
using UnityEngine;
using Zenject;

namespace Animals.Spawner.Model
{
    public interface ISpawnerData : ISpawnerInitData
    {
        public ObservableCollection<IPoolable<Vector3, IMemoryPool>> SpawnedComponents { get; }
    }
}