using StateMachine.Infrastructure;
using StateMachine.Mono;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Transition", fileName = "Transition")]
    public class ScriptableTransition : ScriptableObject, ITransition<StateComponent>
    {
        [SerializeField] 
        private ScriptableState _originState;
        [SerializeField] 
        private ScriptableCondition _condition;
        [SerializeField] 
        private ScriptableState _trueState;
        [SerializeField] 
        private ScriptableState _falseState;
        
        public IState<StateComponent> OriginState { get => _originState; }
        public ICondition<StateComponent> Condition { get => _condition; }
        public IState<StateComponent> TrueState { get => _trueState; }
        public IState<StateComponent> FalseState { get => _falseState; }
    }
}