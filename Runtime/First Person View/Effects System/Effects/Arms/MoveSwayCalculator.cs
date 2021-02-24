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
	public class MoveSwayCalculator {
		public float Period {
			get => period;
			set => period = value;
		}
		public float LateralAmplitude {
			get => lateralAmplitude;
			set => lateralAmplitude = value;
		}
		public float VerticalAmplitude {
			get => verticalAmplitude;
			set => verticalAmplitude = value;
		}

		[SerializeField]
		private float period = 2.0F;
		[SerializeField]
		private float lateralAmplitude = 0.005F;
		[SerializeField]
		private float verticalAmplitude = 0.005F;

		public Vector3 GetSwayPosition(float t) {
			var amplitudeX = lateralAmplitude;
			var amplitudeY = verticalAmplitude;
			var x = amplitudeX * (2.0F * Mathf.PingPong(t, (period / 2.0F)) / (period / 2.0F) - 1.0F);
			var y = amplitudeY * -Mathf.Abs(Mathf.Sin(t / period * (2.0F * Mathf.PI)));

			return new Vector3(x, y, 0.0F);
		}
	}
}
