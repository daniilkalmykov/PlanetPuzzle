using System.Numerics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Lil_biba.PlanetPuzzle.SpawnerSystem")]
namespace MovementSystem
{
    internal sealed class Movement : IMovable
    {
        private const float DistanceToReach = 0.05f;
        
        public Movement(float speed)
        {
            Speed = speed;
        }

        public float Speed { get; }
        public bool Reached { get; private set; }

        public void Move(Vector3 target, float deltaTime, ref Vector3 currentPosition)
        {
            currentPosition = Vector3.Lerp(currentPosition, target, Speed * deltaTime);

            Reached = Vector3.Distance(currentPosition, target) <= DistanceToReach;
        }
    }
}