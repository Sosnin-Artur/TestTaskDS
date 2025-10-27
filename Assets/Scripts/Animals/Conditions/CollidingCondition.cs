using StateMachine.Mono;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Animals.Conditions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Conditions/CollidingCondition", fileName = "new CollidingCondition")]
    public class CollidingCondition : ScriptableCondition
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _hitMask;

        public override bool Verify(StateComponent statesComponent)
        {
            var transform = statesComponent.transform;
            var hits = Physics.OverlapSphere(transform.position, _radius, _hitMask, QueryTriggerInteraction.Collide);
            
            var state = (hits.Length - 1) > 0;

            return state;
        }
    }
}