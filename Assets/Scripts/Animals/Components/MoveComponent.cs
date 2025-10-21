using Animals.Interfaces;
using UnityEngine;

namespace Animals.Components
{
    public class MoveComponent : MonoBehaviour, IMovable
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        
        public virtual void Move(float speed)
        {
            var direction = Random.insideUnitCircle;
            _rigidbody.linearVelocity = speed * new Vector3(direction.x, 0, direction.y);    
        }
    }
}