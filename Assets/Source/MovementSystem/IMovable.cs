using System.Numerics;

namespace MovementSystem
{
    public interface IMovable
    {
        public float Speed { get; }
        public bool Reached { get; }
        
        void Move(Vector3 target, float deltaTime, ref Vector3 currentPosition);
    }
}