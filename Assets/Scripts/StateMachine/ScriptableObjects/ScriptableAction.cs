using StateMachine.Infrastructure;
using StateMachine.Mono;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    public abstract class ScriptableAction : ScriptableObject, IAction<StateComponent>
    {
        public virtual void SetUp(StateComponent setUpObject)
        {
        }

        public abstract void Act(StateComponent statesComponent);
    }
}