/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using UnityEngine;

namespace Andtech.Ego {

	public interface IProjectileTask {
		Vector3 CurrentPosition { get; }

		void Run();

		#region EVENT
		event EventHandler<ImpactEventArgs> Impacted;
		#endregion
	}

	public interface IProjectileTaskLifetime {

		#region PIPELINE
		event EventHandler Launched;
		event EventHandler Destroyed;
		#endregion
	}
}
