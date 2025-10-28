using UnityEditor;
using UnityEngine;
using Zenject;

namespace UI.Installers
{
    public class FloatingTextPoolInstaller : MonoInstaller
    {
        [SerializeField]
        private FloatingText _prefab;
        [SerializeField]
        private int _poolInitialSize;
        [SerializeField]
        private string _transformGroupName;

        public override void InstallBindings()
        {
            Container
                   .BindFactory<string, Vector3, FloatingText, FloatingText.Factory>()                   
                       .FromMonoPoolableMemoryPool(
                            x => x.WithInitialSize(_poolInitialSize)
                            .FromComponentInNewPrefab(_prefab)
                            .UnderTransformGroup(_transformGroupName));
        }
    }
}