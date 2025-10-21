using System;
using StateMachine.Infrastructure;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace StateMachine.Mono
{
    public class StateComponent : MonoBehaviour, IComponent
    {
        [SerializeField] private ScriptableStateMachine _stateMachine;
        
        private IState<StateComponent> _currentState;

        public IState<StateComponent> CurrentState { get => _currentState; }

        private void Start()
        {
            if (_stateMachine.InitialState == null)
            {
                Debug.LogError($"{_stateMachine.name} has no initial state attached to it.", this);
                return;
            }

            _currentState = _stateMachine.InitialState;
            _currentState.Begin(this);
        }

        private void FixedUpdate()
        {
            if (CheckExistence())
                return;

            _currentState.FixedUpdateState(this, Time.fixedDeltaTime);
        }
        
        
        private void Update()
        {
            if (CheckExistence())
                return;

            _currentState.UpdateState(this, Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (CheckExistence())
                return;

            CheckTransitions();
        }

        public void CheckTransitions()
        {
            var nextState = _stateMachine.CheckTransitions(this, _currentState);
            
            if (nextState != _stateMachine.EmptyState)
            {
                _currentState.End(this);
                var previousState = CurrentState;
                _currentState = nextState;
                _currentState.Begin(this);

            }
        }

        private bool CheckExistence()
        {
            return _currentState == null;
        }
    }
}