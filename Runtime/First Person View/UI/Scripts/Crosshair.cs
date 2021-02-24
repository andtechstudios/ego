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

	public class Crosshair : MonoBehaviour {
		public Camera Camera {
			get => camera;
			set => camera = value;
		}
		public float Alpha {
			set => canvasGroup.alpha = value;
		}
		public Vector2 Scale {
			get;
			set;
		} = Vector2.one;
		public Func<Vector2> AngleStrategy { get; set; }
		public RectTransform Target => target;

		private RectTransform target;
		[SerializeField]
		private CanvasGroup canvasGroup;
		[SerializeField]
		private Camera camera;

		private float virtualDepth;

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			target = transform as RectTransform;
		}

		protected virtual void LateUpdate() {
			Rebuild();

			var range = AngleStrategy?.Invoke() ?? Vector2.zero;
			var width = virtualDepth * Mathf.Tan((range.x / 2.0F) * Mathf.Deg2Rad);
			var height = virtualDepth * Mathf.Tan((range.y / 2.0F) * Mathf.Deg2Rad);

			var sizeDelta = new Vector2(width, height);
			Target.sizeDelta = Vector2.Scale(sizeDelta, Scale);

			void Rebuild() {
				float angle = camera.fieldOfView / 2.0F;
				virtualDepth = Screen.height * (1.0F / Mathf.Tan(angle * Mathf.Deg2Rad));
			}
		}
		#endregion
	}
}
