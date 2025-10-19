using System.Collections.Generic;
using System.Timers;

namespace StateMachine.Infrastructure
{    
    public interface IState<T> where T : IComponent
    {
        public void Begin(T component);
        public void UpdateState(T component, float deltaTime);
        public void FixedUpdateState(T component, float fixedDeltaTime);
        public void End(T component);
    }
}
