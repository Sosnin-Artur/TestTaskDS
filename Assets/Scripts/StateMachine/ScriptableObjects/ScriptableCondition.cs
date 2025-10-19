using StateMachine.Infrastructure;
using StateMachine.Mono;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    public abstract class ScriptableCondition : ScriptableObject, ICondition<StateComponent>
    {
        public virtual void SetUp(StateComponent component)
        {
        }

        public abstract bool Verify(StateComponent component);
    }
}