using StateMachine.Mono;
using UnityEngine;

namespace Animals.Actions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Actions/MovementToCenterAction", fileName = "new MovementToCenterAction")]
    public class MovementToCenterAction : MovementAction
    {
        public override Vector3 MakeDirectioin(StateComponent component)
        {
            component.transform.LookAt(Vector3.zero);
            
            return component.transform.forward;
        }
    }
}