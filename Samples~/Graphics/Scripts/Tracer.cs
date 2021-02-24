/*
 *	Copyright (c) 2020, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using UnityEngine;

namespace Andtech.Ego {

	public class Tracer : MonoBehaviour {
		[SerializeField]
		private float maxTailLength;
		[SerializeField]
		private float maxSpeed;
		[SerializeField]
		private LineRenderer lineRenderer;

		private Func<Vector3> positionStrategy;
		private Vector3 origin;
		private Vector3 headPosition;
		private Vector3 tailPosition;
		private float headDistance;
		private float tailDistance;

		public void Preset(Vector3 origin, Vector3 forward, Func<Vector3> positionStrategy) {
			this.origin = origin;
			this.positionStrategy = positionStrategy;
			var delta = positionStrategy() - origin;
			headDistance = maxTailLength;
			tailDistance = 0.0F;
			headPosition = origin + forward * headDistance;
			tailPosition = origin + forward * tailDistance;

			Rebuild();
		}

		public void StopTracking() {
			var terminus = positionStrategy?.Invoke() ?? Vector3.zero;
			positionStrategy = () => terminus;
		}

		private void Rebuild() {
			transform.position = tailPosition;
			transform.rotation = Quaternion.LookRotation(headPosition - tailPosition);

			lineRenderer.SetPosition(0, tailPosition);
			lineRenderer.SetPosition(1, headPosition);
		}

		#region MONOBEHAVIOUR
		protected virtual void Update() => Rebuild();

		protected virtual void LateUpdate() {
			var position = positionStrategy?.Invoke() ?? Vector3.zero;
			var headPosition = Vector3.MoveTowards(this.headPosition, position, maxSpeed * Time.deltaTime);
			var tailPosition = Vector3.MoveTowards(this.tailPosition, headPosition, maxSpeed * Time.deltaTime);
			float headStep = Vector3.Distance(this.headPosition, headPosition);
			float tailStep = Vector3.Distance(this.tailPosition, tailPosition);
			bool headIsThere = Mathf.Approximately((headPosition - position).sqrMagnitude, Mathf.Epsilon);
			bool tailIsThere = Mathf.Approximately((tailPosition - position).sqrMagnitude, Mathf.Epsilon);

			if (tailIsThere) {
				requestedReclaim?.Invoke(this, EventArgs.Empty);
			}

			this.headPosition = headPosition;
			this.tailPosition = tailPosition;
			headDistance += headStep;
			tailDistance += tailStep;
		}
		#endregion

		#region EVENT
		private event EventHandler requestedReclaim;
		#endregion
	}
}
