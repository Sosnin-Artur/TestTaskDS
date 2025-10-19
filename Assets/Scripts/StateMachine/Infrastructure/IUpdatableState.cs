using System.Collections.Generic;

namespace StateMachine.Infrastructure
{    
    public interface IUpdatableState<T> : IState<T>, IUpdatable 
        where T : IComponent
    {
        public List<IAction<T>> UpdatableActions { get; }
    }
}
