using Animals.Components;
using Animals.Interfaces;
using Animals.Spawner.Model;
using Animals.Spawner.View;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Animals.Spawner.Presenter
{
    //TODO: Take out of def to separate independant def
    public class SpawnerPresenter : IPresenter, IInitializable
    {
        private readonly ISpawnerData _data;
        private readonly ISpawnerView _view;
        private readonly AnimalComponent.Factory _factory; //TODO: In real projects prefer to use interfaces of factory

        public SpawnerPresenter(ISpawnerData data, ISpawnerView view, AnimalComponent.Factory factory)
        {
            _data = data;
            _view = view;
            _factory = factory;
        }

        public void Initialize()
        {
            StartSpawnAsync();
        }

        private async UniTask<bool> StartSpawnAsync()
        {
            while (true)
            {
                await UniTask.WaitForSeconds(Random.Range(_data.MinCooldown, _data.MaxCooldown));

                Spawn();
            }
        }

        private void Spawn()
        {
            var position = Random.insideUnitCircle;
            var component = _factory.Create(new Vector3(position.x, 0, position.y) * Random.Range(0, _data.SpawnRadious));
            _data.SpawnedComponents.Add(component);

            component.DespawnedEvent += OnDespawned;
        }

        private void OnDespawned(IDespawnable despawnable)
        {
            despawnable.DespawnedEvent -= OnDespawned;
            _data.SpawnedComponents.Remove(despawnable);
            _data.DespawnedComponents.Add(despawnable);
            _view.SetUp(_data);
        }
    }
}
