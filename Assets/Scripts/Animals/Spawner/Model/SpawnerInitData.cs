using UnityEngine;

namespace Animals.Spawner.Model
{
    [CreateAssetMenu(menuName = "Spawner/Init Data", fileName = "InitData")]
    public class SpawnerInitData : ScriptableObject, ISpawnerInitData
    {
        [SerializeField]
        private float _minCooldown;
        [SerializeField]
        private float _maxCooldown;
        [SerializeField]
        private float _spawnRadious;

        public float MinCooldown => _minCooldown;
        public float MaxCooldown => _maxCooldown;
        public float SpawnRadious => _spawnRadious;
    }
}