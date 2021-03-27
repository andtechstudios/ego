/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Andtech.Ego {

	[Serializable]
	public class ViewKickModule : EffectModule, IRotationEffect {
		public MinMaxCurve VerticalRecoilCurve {
			get => calculator.VerticalRecoilCurve;
			set => calculator.VerticalRecoilCurve = value;
		}
		public MinMaxCurve LateralRecoilCurve {
			get => calculator.LateralRecoilCurve;
			set => calculator.LateralRecoilCurve = value;
		}
		public Vector2 Range {
			get => calculator.Range;
			set => calculator.Range = value;
		}

		[SerializeField]
		private ViewKickCalculator calculator;

		private Coroutine coroutine;

		public Coroutine Play() {
			if (coroutine != null) {
				StopCoroutine(coroutine);
				coroutine = null;
			}

			coroutine = StartCoroutine?.Invoke(calculator.Play(0.333F));

			return coroutine;
		}

		#region INTERFACE
		[TransformEffect(FirstPersonViewAnchor.CameraWorld)]
		Vector3 IRotationEffect.GetRotation() => calculator.GetKickRotation();
		#endregion
	}
}
