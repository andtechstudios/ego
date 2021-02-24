﻿using System;
using UnityEngine;

namespace Andtech.Ego {

	[Serializable]
	public class TurnCalculator {
		public Transform Source {
			get => source;
			set => source = value;
		}
		public float MaxAngularSpeed {
			get => maxAngularSpeed;
			set => maxAngularSpeed = value;
		}
		public float AngleOffset {
			get => angleOffset;
			set => angleOffset = value;
		}
		public float SmoothTime {
			get => smoothTime;
			set => smoothTime = value;
		}

		[SerializeField]
		private Transform source;
		[SerializeField]
		private float maxAngularSpeed = 360.0F;
		[SerializeField]
		private float angleOffset = 2.0F;
		[SerializeField]
		private float smoothTime = 0.175F;

		private float pitchVelocity = 0.0F;
		private float yawVelocity = 0.0F;
		private Quaternion lastSourceRotation;
		private Vector3 eulerAngles;

		public Vector3 GetTurnRotation() {
			var velocity = GetAngularVelocity();
			var pitchSpeed = Vector3.Dot(lastSourceRotation * Vector3.right, velocity);
			var yawSpeed = Vector3.Dot(lastSourceRotation * Vector3.up, velocity);

			var targetPitch = Mathf.Clamp(pitchSpeed, -maxAngularSpeed, maxAngularSpeed) / maxAngularSpeed;
			var targetYaw = Mathf.Clamp(yawSpeed, -maxAngularSpeed, maxAngularSpeed) / maxAngularSpeed;

			var pitch = Mathf.SmoothDampAngle(eulerAngles.x, targetPitch * angleOffset, ref pitchVelocity, smoothTime);
			var yaw = Mathf.SmoothDampAngle(eulerAngles.y, targetYaw * angleOffset, ref yawVelocity, smoothTime);

			eulerAngles = new Vector3 {
				x = pitch,
				y = yaw,
				z = 0.0F
			};

			lastSourceRotation = source.rotation;

			return eulerAngles;
		}

		#region PIPELINE
		private Vector3 GetAngularVelocity() => GetAngularVelocity(lastSourceRotation, source.rotation);

		private Vector3 GetAngularVelocity(Quaternion from, Quaternion to) {
			Quaternion deltaRotation = to * Quaternion.Inverse(from);
			Vector3 eulerRotation = new Vector3 {
				x = Mathf.DeltaAngle(0.0F, deltaRotation.eulerAngles.x),
				y = Mathf.DeltaAngle(0.0F, deltaRotation.eulerAngles.y),
				z = Mathf.DeltaAngle(0.0F, deltaRotation.eulerAngles.z)
			};

			return eulerRotation / Time.deltaTime;
		}
		#endregion
	}
}
