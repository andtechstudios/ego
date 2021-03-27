/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;

namespace Andtech.Ego {

	public class DynamicsFactoryEventArgs<TArgs, TTask> : EventArgs {
		public readonly TTask Task;
		public readonly TArgs Args;

		public DynamicsFactoryEventArgs(TTask task) {
			Task = task;
		}

		public DynamicsFactoryEventArgs(TArgs args, TTask task) {
			Args = args;
			Task = task;
		}
	}
}
