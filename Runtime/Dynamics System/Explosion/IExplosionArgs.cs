/*
 *	Copyright (c) 2020, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	public interface IExplosionArgs {
		Vector3 Position { get; }
		float Radius { get; }
		LayerMask CollisionMask { get; }
	}
}
