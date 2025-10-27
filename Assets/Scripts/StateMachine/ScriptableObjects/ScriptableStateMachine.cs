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
            foreach (ITransition<StateComponent> transition in _transitions)
            {
                if (transition.OriginState == currentState)
                {
                    if (transition.Condition != null)
                    {
                        if (transition.Condition.Verify(stateComponent))
                        {
                            if (transition.TrueState != _emptyState)
                            {
                                if (transition.TrueState != null)
                                {
                                    return transition.TrueState;
                                }
                                else
                                {
                                    Debug.LogError($"{name}'s Transitions list has an element with a null true state", this);
                                }
                            }
                        }
                        else
                        {
                            if (transition.FalseState != _emptyState)
                            {
                                if (transition.FalseState != null)
                                {
                                    return transition.FalseState;
                                }
                                else
                                {
                                    Debug.LogError($"{name}'s Transitions list has an element with a null false state", this);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError($"{name}'s Transitions list has an element with a null Condition", this);
                    }
                }
            }
            return _emptyState;
        }

    }
}