using UnityEngine;
using Zenject;

namespace UI.Installers
{
    [CreateAssetMenu(menuName = "Installers/FloatingTextPoolInstaller")]
    public class FloatingTextPoolInstaller : ScriptableObjectInstaller<FloatingTextPoolInstaller>
    {
        [SerializeField]
        private ScriptableObject _scriptableObject;
        [SerializeField]
        private FloatingText _prefab;
        [SerializeField]
        private int _poolInitialSize;
        [SerializeField]
        private string _transformGroupName;

        public override void InstallBindings()
        {
            Container.QueueForInject(_scriptableObject);

            Container
                   .BindFactory<string, Vector3, FloatingText, FloatingText.Factory>()                   
                       .FromMonoPoolableMemoryPool(
                            x => x.WithInitialSize(_poolInitialSize)
                            .FromComponentInNewPrefab(_prefab)
                            .UnderTransformGroup(_transformGroupName));
        }
    }
}