using Animals.Components;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Animals.Pool.Installers
{
    public class AnimalsPoolInstaller : MonoInstaller
    {
        [SerializeField]
        private AnimalComponent _prefab;
        [SerializeField]
        private int _poolInitialSize;
        [SerializeField]
        private string _transformGroupName;

        public override void InstallBindings()
        {
            Container
                   .BindFactory<Vector3, AnimalComponent, AnimalComponent.Factory>()                   
                       .FromMonoPoolableMemoryPool(
                            x => x.WithInitialSize(_poolInitialSize)
                            .FromComponentInNewPrefab(_prefab)
                            .UnderTransformGroup(_transformGroupName));
        }
    }
}