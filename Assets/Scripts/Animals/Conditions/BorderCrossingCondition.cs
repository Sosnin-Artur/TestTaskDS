using StateMachine.Mono;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Animals.Conditions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Conditions/BorderCrossingCondition", fileName = "new BorderCrossingCondition")]
    public class BorderCrossingCondition : ScriptableCondition
    {
        [SerializeField] 
        private Vector3 _center;
        [SerializeField] 
        private Vector3 _size;

        public Vector3 Center => _center;
        public Vector3 Size => _size;

        public override bool Verify(StateComponent statesComponent)
        {
            var half = new Vector3(Size.x / 2, 0, Size.y / 2);
            var c = Center;

            var transform = statesComponent.transform;

            if (transform.position.x < (c + half).x && transform.position.x > -(c + half).x
                && transform.position.z < (c + half).z && transform.position.z > -(c + half).z)
            {
                return false;
            }
            return true;
        }
    }
}