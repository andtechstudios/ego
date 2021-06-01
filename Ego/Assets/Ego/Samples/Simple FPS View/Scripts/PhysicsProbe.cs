using System;
using UnityEngine;

namespace Andtech.Ego
{

    public class PhysicsProbe
    {
        public Vector3 Velocity { get; private set; }
        public Vector3 Acceleration { get; private set; }
        public float Speed { get; private set; }

        private Func<Vector3> PositionStrategy;
        private Func<Vector3> VelocityStrategy;
        private Vector3 lastPosition;

        private PhysicsProbe() { }

        public void Update()
        {
            Vector3 nextVelocity;
            if (VelocityStrategy != null)
            {
                nextVelocity = VelocityStrategy();
            }
            else
            {
                var nextPosition = PositionStrategy();
                nextVelocity = (nextPosition - lastPosition) / Time.deltaTime;

                lastPosition = nextPosition;
            }

            Acceleration = (nextVelocity - Velocity) / Time.deltaTime;
            Velocity = nextVelocity;
            Speed = Velocity.magnitude;
        }

        public static PhysicsProbe Create(Transform transform) => new PhysicsProbe() { PositionStrategy = () => transform.position };

        public static PhysicsProbe Create(Rigidbody rigidbody) => new PhysicsProbe() { VelocityStrategy = () => rigidbody.velocity };

        public static PhysicsProbe Create(CharacterController controller) => new PhysicsProbe() { VelocityStrategy = () => controller.velocity };
    }
}
