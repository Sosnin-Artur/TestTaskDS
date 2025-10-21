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
            _rigidbody.linearVelocity = speed * Vector3.right;    
        }
    }
}