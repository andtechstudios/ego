/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	public class SimpleFPSPlayerDemo : MonoBehaviour {
		public SpreadController spreadController;
		public SpreadProfile spreadProfile;
		public Crosshair crosshair;

		void Start() {
			spreadController.Load(spreadProfile);
			crosshair.Link(spreadController.ActionPoint);
		}
	}
}
