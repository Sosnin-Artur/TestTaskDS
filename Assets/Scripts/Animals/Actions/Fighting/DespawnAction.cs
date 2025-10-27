using Animals.Interfaces;
using StateMachine.Mono;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Animals.Actions.Fighting
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Actions/DespawnAction", fileName = "new DespawnAction")]
    public class DespawnAction : ScriptableAction
    {
        public override void Act(StateComponent statesComponent)
        {
            if (statesComponent.TryGetComponent<IDespawnable>(out IDespawnable despawnable))
            {
                despawnable.Despawn();
            }
        }
    }
}
