using Animals.Interfaces;
using System.Collections.ObjectModel;
using UnityEngine;
using Zenject;

namespace Animals.Spawner.Model
{
    public interface ISpawnerData : ISpawnerInitData
    {
        public ObservableCollection<IDespawnable> SpawnedComponents { get; }
        public ObservableCollection<IDespawnable> DespawnedComponents { get; }
    }
}