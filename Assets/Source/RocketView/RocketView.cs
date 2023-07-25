using System.Runtime.CompilerServices;
using MovementSystem;
using UnityEngine;

[assembly: InternalsVisibleTo("Lil_biba.PlanetPuzzle.SpawnerSystem")]
namespace RocketView
{
    internal sealed class RocketView : MonoBehaviour, IRocketView
    {
        private IMovable _movable;
        private System.Numerics.Vector3 _target;

        private void Update()
        {
            if (_movable == null)
                return;

            var position = transform.position;
            var currentPosition = new System.Numerics.Vector3(position.x, position.y, position.z);

            _movable.Move(_target, Time.deltaTime, ref currentPosition);

            transform.position = new Vector3(currentPosition.X, currentPosition.Y, currentPosition.Z);

            if (_movable.Reached)
                gameObject.SetActive(false);
        }

        public void Init(System.Numerics.Vector3 target, IMovable movable)
        {
            _target = target;
            _movable = movable;
        }
    }
}