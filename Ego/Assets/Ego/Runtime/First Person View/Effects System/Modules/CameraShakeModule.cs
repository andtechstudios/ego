using System;
using System.Collections;
using UnityEngine;

namespace Andtech.Ego {

	[Serializable]
	public class CameraShakeModule : EffectModule, IRotationEffect {
		public float Speed {
			get => calculator.Speed;
			set => calculator.Speed = value;
		}
		public float Offset {
			get => calculator.Offset;
			set => calculator.Offset = value;
		}
		public float ResetSpeed {
			get => calculator.ResetSpeed;
			set => calculator.ResetSpeed = value;
		}

		[SerializeField]
		private CameraShakeCalculator calculator;

		private Coroutine coroutine;
		private float t;

		public Coroutine Play() {
			if (coroutine != null) {
				StopCoroutine(coroutine);
				coroutine = null;
			}

			coroutine = StartCoroutine?.Invoke(Shaking());

			return coroutine;

			IEnumerator Shaking() {
				var duration = 1.0F / calculator.ResetSpeed;
				foreach (var alpha in Tween.Linear(duration)) {
					t = 1.0F - alpha;
					yield return null;
				}
			}
		}

		#region INTERFACE
		[TransformEffect(FirstPersonViewAnchor.CameraWorld)]
		Vector3 IRotationEffect.GetRotation() {
			return t * calculator.GetShakePosition(Time.time);
		}
		#endregion
	}
}
