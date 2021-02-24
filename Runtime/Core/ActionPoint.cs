/*
 *	Copyright (c) 2020, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	public class ActionPoint : MonoBehaviour {
		public float HorizontalAngle {
			get => horizontalAngle;
			set => horizontalAngle = value;
		}
		public float VerticalAngle {
			get => verticalAngle;
			set => verticalAngle = value;
		}
		public Vector3 Position => transform.position;
		public Vector3 Direction => transform.forward;

		[SerializeField]
		private float horizontalAngle;
		[SerializeField]
		private float verticalAngle;

		public Quaternion Sample() {
			var x = Random.Range(-HorizontalAngle / 2.0F, HorizontalAngle / 2.0F);
			var y = Random.Range(-VerticalAngle / 2.0F, VerticalAngle / 2.0F);

			return transform.rotation * Quaternion.Euler(
			   y,
			   x,
			   0.0F);
		}

		#region MONOBEHAVIOUR
		protected virtual void OnDrawGizmos() {
			Gizmos.DrawRay(Position, Direction);
		}

		protected virtual void OnDrawGizmosSelected() {
			var position = Position;
			var rotation = transform.rotation;

			Gizmos.DrawRay(position, rotation * (Quaternion.Euler(0.0F, -HorizontalAngle / 2.0F, 0.0F) * Vector3.forward));
			Gizmos.DrawRay(position, rotation * (Quaternion.Euler(0.0F, HorizontalAngle / 2.0F, 0.0F) * Vector3.forward));
			Gizmos.DrawRay(position, rotation * (Quaternion.Euler(-VerticalAngle / 2.0F, 0.0F, 0.0F) * Vector3.forward));
			Gizmos.DrawRay(position, rotation * (Quaternion.Euler(VerticalAngle / 2.0F, 0.0F, 0.0F) * Vector3.forward));
		}
		#endregion
	}
}
