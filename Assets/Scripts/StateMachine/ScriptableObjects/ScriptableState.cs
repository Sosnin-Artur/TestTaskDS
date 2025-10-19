using System.Collections.Generic;
using System.Linq;
using StateMachine.Infrastructure;
using StateMachine.Mono;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/State", fileName = "State")]
    public class ScriptableState : ScriptableObject, IState<StateComponent>
    {
        [SerializeField] ScriptableAction[] _entryActions;
        [SerializeField] ScriptableAction[] _exitActions;
        [SerializeField] ScriptableAction[] _physicsActions; //to be run in fixed update
        [SerializeField] ScriptableAction[] _updateActions; //to be run in update

        public void Begin(StateComponent stateComponent)
        {
            foreach (var action in _entryActions)
            {
                if (action)
                {
                    action.Act(stateComponent);
                }
                else
                {
                    Debug.LogError($"{name} Entry Actions list has a null element", this);
                }
            }
        }

        public void End(StateComponent stateComponent)
        {
            foreach (var action in _exitActions)
            {
                if (action)
                {
                    action.Act(stateComponent);
                }
                else
                {
                    Debug.LogError($"{name} Exit Actions list has a null element", this);
                }
            }
        }

        public void FixedUpdateState(StateComponent stateComponent, float fixedDeltaTime)
        {
            foreach (var action in _physicsActions)
            {
                if (action)
                {
                    action.Act(stateComponent);
                }
                else
                {
                    Debug.LogError($"{name} Physics Actions list has a null element", this);
                }
            }
        }

        public void UpdateState(StateComponent stateComponent, float deltaTime)
        {
            foreach (var action in _updateActions)
            {
                if (action)
                {
                    action.Act(stateComponent);
                }
                else
                {
                    Debug.LogError($"{name} State Actions list has a null element", this);
                }
            }
        }
    }
}