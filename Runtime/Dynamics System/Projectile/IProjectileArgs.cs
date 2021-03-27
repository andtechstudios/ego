/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	public interface IProjectileArgs {
		Vector3 Origin { get; }
		Vector3 Direction { get; }
		LayerMask CollisionMask { get; }
		float MaxDistance { get; }
		float Speed { get; }
	}
}
