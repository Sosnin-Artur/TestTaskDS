using UnityEngine;

namespace Animals.Interfaces
{
    public interface IMovable
    {
        public void Move(float speed, Vector3 directoin);
    }
}