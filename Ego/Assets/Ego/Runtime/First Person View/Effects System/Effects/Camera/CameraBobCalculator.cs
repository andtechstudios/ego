using System;
using UnityEngine;

namespace Andtech.Ego {

	[Serializable]
	public class CameraBobCalculator {
		public float Amplitude {
			get => amplitude;
			set => amplitude = value;
		}
		public float Period {
			get => period;
			set => period = value;
		}

		[SerializeField]
		private float amplitude = 0.25F;
		[SerializeField]
		private float period = 0.5F;

		public Vector3 GetBobPosition(float t) {
			var y = Amplitude * Mathf.Cos(t / Period * (2.0F * Mathf.PI));

			return new Vector3(0.0F, y, 0.0F);
		}
	}
}
