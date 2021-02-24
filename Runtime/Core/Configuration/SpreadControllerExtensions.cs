/*
 *	Copyright (c) 2020, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

namespace Andtech.Ego {

	public static class SpreadControllerExtensions {

		public static void Load(this SpreadController controller, SpreadProfile profile) {
			controller.AimSpeed = profile.AimSpeed;
			controller.UnfocusMin = profile.UnfocusMin;
			controller.UnfocusMax = profile.UnfocusMax;
			controller.UnfocusKickAmount = profile.UnfocusKickAmount;
			controller.UnfocusResetRate = profile.UnfocusResetRate;
			controller.FocusMin = profile.FocusMin;
			controller.FocusMax = profile.FocusMax;
			controller.FocusKickAmount = profile.FocusKickAmount;
			controller.FocusResetRate = profile.FocusResetRate;
			controller.Rebuild();
		}
	}
}
