using System;
using UnityEngine;

namespace Andtech.Ego {

	public class ImpactEventArgs : EventArgs {
		public readonly Vector3 Point;
		public readonly Vector3 Normal;
		public readonly Collider Collider;

		public ImpactEventArgs(Vector3 point, Vector3 normal, Collider collider) {
			Point = point;
			Normal = normal;
			Collider = collider;
		}
	}
}
