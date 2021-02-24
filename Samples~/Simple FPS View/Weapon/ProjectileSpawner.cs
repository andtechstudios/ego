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

	[Serializable]
	public struct ProjectileSpawner : IProjectileSpawner {
		public IProjectileArgs Args {
			get {
				args.Origin = actionPoint.Position;
				args.Direction = actionPoint.Sample() * Vector3.forward;
				args.DisplayOrigin = actionPoint.Position;

				return args;
			}
		}

		[SerializeField]
		private ActionPoint actionPoint;
		[SerializeField]
		private SimpleProjectileArgs args;
	}
}
