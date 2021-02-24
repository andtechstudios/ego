/*
 *	Copyright (c) 2020, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Collections.Generic;

namespace Andtech.Ego {

	public class DynamicsFactory<TArgs, TTask> {
		private readonly Dictionary<Type, Func<TArgs, TTask>> factories = new Dictionary<Type, Func<TArgs, TTask>>();

		public void Add<T>(Func<TArgs, T> objectFactory) where T : TTask {
			factories.Add(typeof(T), args => objectFactory(args));
		}

		public TTask Initiate(Type type, TArgs args) {
			var hasFactory = factories.TryGetValue(type, out var factory);
			if (hasFactory) {
				var task = factory(args);

				Initiated?.Invoke(this, new DynamicsFactoryEventArgs<TArgs, TTask>(args, task));

				return task;
			}

			return default;
		}

		public T Initiate<T>(TArgs args) where T : TTask {
			var hasFactory = factories.TryGetValue(typeof(T), out var factory);
			if (hasFactory) {
				var task = factory(args);

				Initiated?.Invoke(this, new DynamicsFactoryEventArgs<TArgs, TTask>(args, task));

				return (T)task;
			}

			return default;
		}

		#region EVENT
		public event EventHandler<DynamicsFactoryEventArgs<TArgs, TTask>> Initiated;
		#endregion

	}
}
