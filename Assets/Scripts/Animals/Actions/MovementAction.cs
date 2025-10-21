using System;
using System.Collections.Generic;
using Animals.Interfaces;
using StateMachine.Mono;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Animals.Actions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Actions/MovementAction", fileName = "new MovementAction")]
    public class MovementAction : ScriptableAction
    {
        [SerializeField] private float _speed;
        
        private Dictionary<StateComponent, IMovable> _movables = new();
            
        private void OnEnable()
        {
            _movables.Clear();
        }
        
        public override void SetUp(StateComponent setUpObject)
        {
            _movables[setUpObject] = setUpObject.GetComponent<IMovable>();
        }

        public override void Act(StateComponent statesComponent)
        {
            IMovable movable;
            
            if (_movables.ContainsKey(statesComponent))
            { 
                movable = _movables[statesComponent];
            }
            else
            {
                movable = statesComponent.GetComponent<IMovable>();
                _movables[statesComponent] = movable;
            }
            
            movable.Move(_speed);  
        }
    }
}