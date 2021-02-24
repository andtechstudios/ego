/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Prototyping {

	public class FPSMover : MonoBehaviour {
		[SerializeField]
		private CharacterController controller;
		[SerializeField]
		private Rigidbody rigidbody;
		[SerializeField]
		private Transform vision;

		[SerializeField]
		private float speed;
		[SerializeField]
		private float acceleration;
		[SerializeField]
		private float jumpForce;

		private Vector2 input;
		[SerializeField]
		private bool wantsToJump;

		protected virtual void OnEnable() {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		protected virtual void OnDisable() {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		protected virtual void Update() {
			input.x = Input.GetAxis("Horizontal");
			input.y = Input.GetAxis("Vertical");
			wantsToJump |= Input.GetKeyDown(KeyCode.Space);

			var up = Vector3.up;
			var forward = Vector3.ProjectOnPlane(vision.forward, up).normalized;
			var right = Vector3.Cross(up, forward);

			var velocity = controller.velocity;
			velocity += Physics.gravity * Time.deltaTime;

			var verticalVelocity = Vector3.Project(velocity, Physics.gravity);
			var planarVelocity = Vector3.ProjectOnPlane(velocity, Physics.gravity);
			var desiredVelocity = right * input.x * speed + forward * input.y * speed;
			planarVelocity = Vector3.MoveTowards(planarVelocity, desiredVelocity, acceleration * Time.deltaTime);
			if (wantsToJump) {
				verticalVelocity.y = jumpForce;
				wantsToJump = false;
			}

			velocity = planarVelocity + verticalVelocity;

			controller.Move(velocity * Time.deltaTime);
		}
	}
}
