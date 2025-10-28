using Animals.Interfaces;
using UnityEngine;

namespace Animals.Components.Movement
{
    public class LinearMoveComponent : MoveComponent
    {
        public override void Move(float speed, Vector3 direction)
        {
           Rigidbody.linearVelocity = speed * direction;    
        }
    }
}