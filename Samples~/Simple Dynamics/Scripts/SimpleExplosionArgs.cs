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

	[Serializable]
	public struct SimpleExplosionArgs : IExplosionArgs {
		public Vector3 Position {
			get => position;
			set => position = value;
		}
		public float Radius {
			get => radius;
			set => radius = value;
		}
		public LayerMask CollisionMask {
			get => collisionMask;
			set => collisionMask = value;
		}
		public float Damage { get; set; }

		[SerializeField]
		private Vector3 position;
		[SerializeField]
		private float radius;
		[SerializeField]
		private LayerMask collisionMask;
	}
}
