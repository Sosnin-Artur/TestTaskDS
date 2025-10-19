using System.Collections.Generic;

namespace StateMachine.Infrastructure
{    
    public interface IPhysicsState<T> : IState<T>, IPhysicsUpdatable 
        where T : IComponent
    {
        public List<IAction<T>> PhysicsActions { get; }

    }
}
