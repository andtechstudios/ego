/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	public class WeaponRig : MonoBehaviour {
		public Transform Root => root;
		public Transform RearHand => rearHand;
		public Transform FrontHand => frontHand;
		public Transform RearSight => rearSight;
		public Transform FrontSight => frontSight;
		public Transform Muzzle => muzzle;

		[SerializeField]
		private Transform root;
		[SerializeField]
		private Transform rearHand;
		[SerializeField]
		private Transform frontHand;
		[SerializeField]
		private Transform rearSight;
		[SerializeField]
		private Transform frontSight;
		[SerializeField]
		private Transform muzzle;
	}
}
