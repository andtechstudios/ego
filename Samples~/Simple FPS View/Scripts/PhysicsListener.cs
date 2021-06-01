/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego
{

    public class PhysicsListener : MonoBehaviour
    {
        [SerializeField]
        public SimpleFPSPlayer player;
        [SerializeField]
        private float accelerationThreshold = 100.0f;
        [SerializeField]
        private float minBounceSpeed = 5.0f;
        [SerializeField]
        private float maxBounceSpeed = 50.0f;
        [SerializeField]
        private float minBobSpeed = 2.0f;
        [SerializeField]
        private float maxBobSpeed = 20.0f;
        [SerializeField]
        private float acceleration = 1.0f;

        private Vector3 lastVelocity;

        [SerializeField]
        private CharacterController controller;
        private PhysicsProbe probe;
        private FloatInterpolator move;

        #region MONOBEHAVIOUR
        protected virtual void Awake()
        {
            probe = PhysicsProbe.Create(controller);
            move = FloatInterpolator.Linear(acceleration);
        }

        protected virtual void FixedUpdate()
        {
            probe.Update();

            move.Target = Mathf.InverseLerp(minBobSpeed, maxBobSpeed, probe.Speed);
            move.MoveTowards();
            player.EffectSystem.CameraBobModule.Intensity = move.Current;
            player.EffectSystem.MoveSwayModule.Intensity = move.Current;

            if (probe.Acceleration.y > accelerationThreshold)
            {
                var alpha = Mathf.InverseLerp(minBounceSpeed, maxBounceSpeed, Mathf.Abs(lastVelocity.y));

                if (lastVelocity.y < 0.0f)
                {
                    player.EffectSystem.BounceModule.Play(alpha);
                }
            }

            lastVelocity = probe.Velocity;
        }
        #endregion
    }
}
