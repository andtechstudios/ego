/*
 *	Copyright (c) 2020, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	public class ActionPointController {
		public ActionPoint ActionPoint => actionPoint;
		public float ResetRate { get; set; } = 100.0F;
		public Vector2 MinRange { get; set; } = Vector2.zero;
		public Vector2 MaxRange { get; set; } = Vector2.zero;
		public Vector2 Range {
			get => new Vector2(actionPoint.HorizontalAngle, actionPoint.VerticalAngle);
			set {
				actionPoint.HorizontalAngle = value.x;
				actionPoint.VerticalAngle = value.y;
			}
		}

		private readonly ActionPoint actionPoint;

		public ActionPointController(ActionPoint actionPoint) {
			this.actionPoint = actionPoint;
		}

		public void Add(Vector2 increment) {
			var sum = Range + increment;
			sum.x = Mathf.Clamp(sum.x, MinRange.x, MaxRange.x);
			sum.y = Mathf.Clamp(sum.y, MinRange.y, MaxRange.y);
			Range = sum;
		}

		public void Move() {
			var range = new Vector2 {
				x = Mathf.MoveTowards(Range.x, 0.0F, Time.deltaTime * ResetRate),
				y = Mathf.MoveTowards(Range.y, 0.0F, Time.deltaTime * ResetRate)
			};

			range.x = Mathf.Clamp(range.x, MinRange.x, MaxRange.x);
			range.y = Mathf.Clamp(range.y, MinRange.y, MaxRange.y);

			Range = range;
		}
	}
}
