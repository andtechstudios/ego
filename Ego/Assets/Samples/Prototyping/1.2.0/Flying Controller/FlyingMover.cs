/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Prototyping
{

    public class FlyingMover : MonoBehaviour
    {
        [SerializeField]
        private CharacterController controller;
        [SerializeField]
        public Transform vision;
        [SerializeField]
        private float speed = 6.0f;

        protected virtual void Update()
        {
            var input = new Vector3
            {
                x = GetAxis(KeyCode.A, KeyCode.D),
                y = GetAxis(KeyCode.Q, KeyCode.E),
                z = GetAxis(KeyCode.S, KeyCode.W)
            };

            var b1 = vision.up;
            var b0 = vision.right;
            var b2 = vision.forward;

            if (Mathf.Approximately(b2.sqrMagnitude, 0.0f))
            {
                b0 = Vector3.right;
                b2 = Vector3.forward;
            }

            var multiplier = Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;
            var speed = this.speed * multiplier;
            var velocity =
                speed * input.x * b0
                + speed * input.y * b1
                + speed * input.z * b2;

            controller.Move(velocity * Time.deltaTime);

            float GetAxis(KeyCode negativeKey, KeyCode positiveKey)
            {
                if (Input.GetKey(negativeKey))
                    return -1.0f;

                if (Input.GetKey(positiveKey))
                    return 1.0f;

                return 0.0f;
            }
        }
    }
}
