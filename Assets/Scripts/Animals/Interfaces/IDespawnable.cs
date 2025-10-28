using System;

namespace Animals.Interfaces
{
    public interface IDespawnable
    {
        public event Action<IDespawnable> DespawnedEvent;
        public void Despawn();
    }
}