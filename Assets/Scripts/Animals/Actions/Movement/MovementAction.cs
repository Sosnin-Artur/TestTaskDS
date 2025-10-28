using System.Collections.Generic;
using Animals.Interfaces;
using StateMachine.Mono;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Animals.Actions
{
    public abstract class MovementAction : ScriptableAction, IDirectable
    {
        [SerializeField] 
        private float _speed;
        
        private Dictionary<StateComponent, IMovable> _movables = new();

        public float Speed => _speed;

        public Dictionary<StateComponent, IMovable> Movables => _movables;

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
            
            var direction = MakeDirectioin(statesComponent);
            movable.Move(_speed, direction);  
        }

        public abstract Vector3 MakeDirectioin(StateComponent component);
    }
}