/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	[CreateAssetMenu(fileName = "Spread Profile", menuName = "Andtech/Ego/Spread Profile", order = 99)]
	public class SpreadProfile : ScriptableObject {
		public float AimSpeed => aimSpeed;
		public Vector2 UnfocusMin => unfocusMin;
		public Vector2 UnfocusMax => unfocusMax;
		public Vector2 UnfocusKickAmount => unfocusKickAmount;
		public float UnfocusResetRate => unfocusResetRate;
		public Vector2 FocusMin => focusMin;
		public Vector2 FocusMax => focusMax;
		public Vector2 FocusKickAmount => focusKickAmount;
		public float FocusResetRate => focusResetRate;

		[SerializeField]
		private float aimSpeed = 8.0F;

		[Header("Unfocused Parameters")]
		[SerializeField]
		private Vector2 unfocusMin = new Vector2(6.0F, 6.0F);
		[SerializeField]
		private Vector2 unfocusMax = new Vector2(30.0F, 30.0F);
		[SerializeField]
		private Vector2 unfocusKickAmount = new Vector2(8.0F, 8.0F);
		[SerializeField]
		private float unfocusResetRate = 64.0F;

		[Header("Focused Parameters")]
		[SerializeField]
		private Vector2 focusMin = new Vector2(0.0F, 0.0F);
		[SerializeField]
		private Vector2 focusMax = new Vector2(3.0F, 3.0F);
		[SerializeField]
		private Vector2 focusKickAmount = new Vector2(2.5F, 2.5F);
		[SerializeField]
		private float focusResetRate = 24.0F;
	}
}
