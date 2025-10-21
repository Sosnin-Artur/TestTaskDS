using System;
using System.Collections.Generic;
using StateMachine.Infrastructure;
using StateMachine.Mono;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
     [CreateAssetMenu(menuName = "Scriptable State Machine/State Machine", fileName = "State Machine")]
    public class ScriptableStateMachine : ScriptableObject, IStateMachine<StateComponent>   
    {
        [SerializeField] private ScriptableState _initialState;
        [SerializeField] private ScriptableState _emptyState;
        [SerializeField] private List<ScriptableTransition> _transitions;

        public IState<StateComponent> InitialState { get => _initialState; }
        public IState<StateComponent> EmptyState { get => _emptyState; }

        public IState<StateComponent> CheckTransitions(StateComponent stateComponent
            , IState<StateComponent> currentState)
        {
            foreach (var transition in _transitions)
            {
                if (transition.OriginState == currentState)
                {
                    if (transition.Condition != null)
                    {
                        if (VerifyCondition(stateComponent, transition, out var transitionTrueState))
                        {
                            return transitionTrueState;
                        }
                    }
                    else
                    {
                        Debug.LogError($"{name} Transitions list has an element with a null condition", this);
                    }
                }
            }
            
            return _emptyState;
        }

        private bool VerifyCondition(StateComponent stateComponent, ScriptableTransition transition,
            out IState<StateComponent> transitionState)
        {
            if (transition.Condition.Verify(stateComponent))
            {
                if (transition.TrueState != null)
                {
                    transitionState = transition.TrueState;
                        
                    return true;
                }
                else
                {
                    throw new Exception($"{name} Transitions list has an element with a null true state");
                }
            }
            else
            {
                if (transition.FalseState != null)
                {
                    transitionState = transition.FalseState;
                        
                    return true;
                }
                else
                {
                    throw new Exception($"{name} Transitions list has an element with a null false state");
                }
            }
        }
    }
}