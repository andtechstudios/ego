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
