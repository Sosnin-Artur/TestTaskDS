using StateMachine.Mono;
using UnityEngine;
using Zenject;

namespace Animals.Components
{
    public class AnimalComponent : StateComponent, IPoolable<Vector3, IMemoryPool>
    {
        private IMemoryPool _pool;
        private Transform _transform;

        public void Awake()
        {
            _transform = transform;    
        }

        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            _pool = pool;
            _transform.position = position;
        }

        public void OnDespawned()
        {
            _pool = null;
        }
        public class Factory : PlaceholderFactory<Vector3, AnimalComponent>
        {
        }
    }
}