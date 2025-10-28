using Animals.Interfaces;
using UnityEngine;

namespace Animals.Components.Movement
{
    public abstract class MoveComponent : MonoBehaviour, IMovable
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        public Rigidbody Rigidbody { get => _rigidbody; }

        public abstract void Move(float speed, Vector3 direction);
    }
}