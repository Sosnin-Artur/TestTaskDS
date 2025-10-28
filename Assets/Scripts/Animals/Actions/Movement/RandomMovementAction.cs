using StateMachine.Mono;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Animals.Actions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Actions/RandomMovementAction", fileName = "new MovementAction")]
    public class RandomMovementAction : MovementAction
    {
        public override Vector3 MakeDirectioin(StateComponent component)
        {
            var dir = Random.insideUnitCircle;
            
            return new Vector3(dir.x, 0, dir.y);
        }
    }
}