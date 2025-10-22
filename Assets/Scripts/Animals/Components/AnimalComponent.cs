using StateMachine.Mono;
using Zenject;

namespace Animals.Components
{
    public class AnimalComponent : StateComponent, IPoolable<IMemoryPool>
    {
        private IMemoryPool _pool;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        public void OnDespawned()
        {
            _pool = null;
        }
        public class Factory : PlaceholderFactory<AnimalComponent>
        {
        }
    }
}