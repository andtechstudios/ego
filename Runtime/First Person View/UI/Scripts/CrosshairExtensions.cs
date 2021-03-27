/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	public static class CrosshairExtensions {

		public static void Link(this Crosshair crosshair, ActionPoint actionPoint) {
			crosshair.AngleStrategy = () => new Vector2(actionPoint.HorizontalAngle, actionPoint.VerticalAngle);
		}
	}
}
