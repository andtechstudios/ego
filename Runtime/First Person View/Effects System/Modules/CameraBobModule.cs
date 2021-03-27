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

	[Serializable]
	public class CameraBobModule : EffectModule, IPositionEffect {
		public float Intensity {
			get => intensity;
			set => intensity = value;
		}
		public float Period {
			get => calculator.Period;
			set => calculator.Period = value;
		}
		public float Amplitude {
			get => calculator.Amplitude;
			set => calculator.Amplitude = value;
		}

		[Range(0.0F, 1.0F)]
		[SerializeField]
		private float intensity = 1.0F;
		[SerializeField]
		private CameraBobCalculator calculator;

		#region INTERFACE
		[TransformEffect(FirstPersonViewAnchor.CameraWorld)]
		Vector3 IPositionEffect.GetPosition() => intensity * calculator.GetBobPosition(Time.time);
		#endregion
	}
}
