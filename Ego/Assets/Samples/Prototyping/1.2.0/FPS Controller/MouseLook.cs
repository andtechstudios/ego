/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Prototyping {

	public class MouseLook : MonoBehaviour {
		[SerializeField]
		private Transform yawAnchor;
		[SerializeField]
		private Transform pitchAnchor;
		[SerializeField]
		private float sensitivityX = 360.0F;
		[SerializeField]
		private float sensitivityY = 360.0F;
		[Range(-90.0F, 90.0F)]
		[SerializeField]
		private float pitchLimit = 85.0F;

		protected virtual void OnEnable() {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		protected virtual void OnDisable() {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}


		protected virtual void LateUpdate() {
			var input = new Vector2 {
				x = Input.GetAxis("Mouse X"),
				y = Input.GetAxis("Mouse Y")
			};

			var yawEulerAngles = yawAnchor.eulerAngles;
			yawEulerAngles.y += input.x * sensitivityX * Time.smoothDeltaTime;
			yawAnchor.eulerAngles = yawEulerAngles;

			var pitchEulerAngles = pitchAnchor.localEulerAngles;
			float pitch = pitchEulerAngles.x;
			float targetPitch = pitch - input.y * sensitivityY * Time.smoothDeltaTime;
			pitch = ClampAngle(targetPitch, -pitchLimit, pitchLimit);
			pitchEulerAngles.x = pitch;
			pitchAnchor.localEulerAngles = pitchEulerAngles;
		}

		public static float ClampAngle(float angle, float min, float max) {
			float start = (min + max) * 0.5f - 180;
			float floor = Mathf.FloorToInt((angle - start) / 360) * 360;
			min += floor;
			max += floor;
			return Mathf.Clamp(angle, min, max);
		}

	}
}
