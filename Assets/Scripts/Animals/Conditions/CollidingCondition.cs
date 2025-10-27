using StateMachine.Mono;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Animals.Conditions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Conditions/CollidingCondition", fileName = "new CollidingCondition")]
    public class CollidingCondition : ScriptableCondition
    {
        [SerializeField] private float _radious;
        [SerializeField] private LayerMask _hitMask;

        public override bool Verify(StateComponent statesComponent)
        {
            var transform = statesComponent.transform;
            var hits = Physics.SphereCastAll(transform.position, _radious, transform.forward, _hitMask.value);
            
            var state = (hits.Length - 1) > 0;

            if (state)
            {
                Debug.Log("test");
            }
            return state;
        }
    }
}