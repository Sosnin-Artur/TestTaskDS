using System.Collections.Generic;

namespace StateMachine.Infrastructure
{    
    public interface IState<T> where T : IComponent
    {
        public List<IAction<T>> EntryActions { get; }
        public List<IAction<T>> ExitActions { get; }
        
        public void Begin(T component);
        public void End(T component);
    }
}
