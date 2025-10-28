using Animals.Interfaces;
using System.Collections.ObjectModel;

namespace Animals.Spawner.Model
{
    public interface ISpawnerData : ISpawnerInitData
    {
        public ObservableCollection<IDespawnable> SpawnedComponents { get; }
        public ObservableCollection<IDespawnable> DespawnedComponents { get; }
    }
}