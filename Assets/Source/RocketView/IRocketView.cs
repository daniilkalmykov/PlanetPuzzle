using System.Numerics;
using MovementSystem;

namespace RocketView
{
    public interface IRocketView
    {
        void Init(Vector3 target, IMovable movable);
    }
}