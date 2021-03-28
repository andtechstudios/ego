/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;

namespace Andtech.Ego {

	public enum FirstPersonViewAnchor {
		CameraWorld,
		CameraFirstPersonView,
		Arms,
		Hand
	}

	public enum TransformComponent {
		Position,
		Rotation,
		Scale
	}

	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	sealed class TransformEffectAttribute : Attribute {
		private readonly FirstPersonViewAnchor anchor;
		private readonly bool useWorldSpace;

		public TransformEffectAttribute(FirstPersonViewAnchor anchor) : this(anchor, false) { }

		public TransformEffectAttribute(FirstPersonViewAnchor anchor, bool useWorldSpace) {
			this.anchor = anchor;
			this.useWorldSpace = useWorldSpace;
		}

		public FirstPersonViewAnchor Anchor => anchor;
		public bool UseWorldSpace => useWorldSpace;
	}
}