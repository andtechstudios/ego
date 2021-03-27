/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

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
