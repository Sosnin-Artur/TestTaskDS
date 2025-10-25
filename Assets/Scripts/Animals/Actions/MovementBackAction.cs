using StateMachine.Mono;
using UnityEngine;

namespace Animals.Actions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Actions/MoveBackAction", fileName = "new MoveBackAction")]
    public class MoveBackAction : MovementAction
    {
        public override Vector3 MakeDirectioin(StateComponent component)
        {
            component.transform.LookAt(-component.transform.forward);
            
            return component.transform.forward;
        }
    }
}