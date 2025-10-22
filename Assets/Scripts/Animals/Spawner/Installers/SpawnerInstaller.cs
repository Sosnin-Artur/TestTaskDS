using Animals.Spawner.Model;
using Animals.Spawner.Presenter;
using Animals.Spawner.View;
using UnityEngine;
using Zenject;

namespace Animals.Spawner.Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        [SerializeField]
        private SpawnerInitData _spawnerInitData;
        [SerializeField]
        private SpawnerView _spawnerView;

        public override void InstallBindings()
        {
            Container
                .BindInstance<ISpawnerInitData>(_spawnerInitData);
                
            Container
                .BindInstance<ISpawnerView>(_spawnerView);
            
            Container
                .Bind<ISpawnerData>()
                .To<SpawnerData>()
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<SpawnerPresenter>()
                .AsSingle();
        }
    }
}