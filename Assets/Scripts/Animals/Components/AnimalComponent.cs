using Animals.Interfaces;
using StateMachine.Mono;
using System;
using UnityEngine;
using Zenject;

namespace Animals.Components
{
    public class AnimalComponent : StateComponent, IPoolable<Vector3, IMemoryPool>, IDespawnable
    {
        public event Action<IDespawnable> DespawnedEvent;
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
            Init();
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void Despawn()
        {
            _pool.Despawn(this);
            DespawnedEvent?.Invoke(this);
        }

        public class Factory : PlaceholderFactory<Vector3, AnimalComponent>
        {
        }
    }
}