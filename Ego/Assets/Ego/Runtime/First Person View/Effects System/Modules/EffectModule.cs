using System;
using System.Collections;
using UnityEngine;

namespace Andtech.Ego {

	public class EffectModule {
		public float Weight {
			get => weight;
			set => weight = value;
		}
		public bool Enabled {
			get => enabled;
			set => enabled = value;
		}
		public Func<IEnumerator, Coroutine> StartCoroutine { get; set; }
		public Action<Coroutine> StopCoroutine { get; set; }

		[SerializeField]
		private bool enabled = true;
		[Range(0.0F, 1.0F)]
		[SerializeField]
		private float weight = 1.0F;
	}
}
