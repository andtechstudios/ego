/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

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
