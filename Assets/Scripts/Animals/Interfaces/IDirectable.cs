using StateMachine.Mono;
using UnityEngine;

namespace Animals.Interfaces
{
    public interface IDirectable
    {
        public Vector3 MakeDirectioin(StateComponent component);
    }
}