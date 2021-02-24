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
	public class CameraShakeCalculator {
		public float Speed {
			get => speed;
			set => speed = value;
		}
		public float Offset {
			get => offset;
			set => offset = value;
		}
		public float ResetSpeed {
			get => resetSpeed;
			set => resetSpeed = value;
		}

		[SerializeField]
		private float speed = 24.0F;
		[SerializeField]
		private float offset = 1.0F;
		[SerializeField]
		private float resetSpeed = 4.0F;

		public Vector3 GetShakePosition(float t) {
			return new Vector3 {
				x = offset * PerlinNoise01(0.0F, speed * t),
				y = offset * PerlinNoise01(1.0F, speed * t),
				z = offset * PerlinNoise01(2.0F, speed * t),
			};

			float PerlinNoise01(float x, float y) => Mathf.PerlinNoise(x, y) * 2.0F - 1.0F;
		}
	}
}
