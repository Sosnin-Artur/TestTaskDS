using Animals.Interfaces;
using UnityEngine;

namespace Animals.Components
{
    public class MoveComponent : MonoBehaviour, IMovable
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        
        public virtual void Move(float speed, Vector3 direction)
        {
            _rigidbody.linearVelocity = speed * direction;    
        }
    }
}