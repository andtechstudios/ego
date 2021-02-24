using System;
using UnityEngine;

namespace Andtech.Ego {

	[Serializable]
	public class BreathCalculator {
		public float Period {
			get => period;
			set => period = value;
		}
		public float HorizontalAmplitude {
			get => horizontalAmplitude;
			set => horizontalAmplitude = value;
		}
		public float VerticalAmplitude {
			get => verticalAmplitude;
			set => verticalAmplitude = value;
		}

		[SerializeField]
		private float period = 3.0F;
		[SerializeField]
		private float horizontalAmplitude = 0.0015F;
		[SerializeField]
		private float verticalAmplitude = 0.002F;

		public Vector3 GetBreathPosition(float t) {
			var x = horizontalAmplitude * Mathf.Cos(t / period * (2.0F * Mathf.PI));
			var y = verticalAmplitude * Mathf.Cos(t / 1.3254F / period * (2.0F * Mathf.PI));

			return new Vector3(x, y, 0.0F);
		}
	}
}
