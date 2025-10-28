using Animals.Spawner.Model;
using TMPro;
using UnityEngine;

namespace Animals.Spawner.View
{
    public class SpawnerView : MonoBehaviour, ISpawnerView
    {
        [SerializeField]
        private TextMeshProUGUI _deathCouter;

        public void SetUp(ISpawnerData data)
        {
            _deathCouter.text = data.DespawnedComponents.Count.ToString();
        }
    }
}
