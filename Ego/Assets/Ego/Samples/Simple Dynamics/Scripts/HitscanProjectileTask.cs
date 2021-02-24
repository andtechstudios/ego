using System;
using UnityEngine;

namespace Andtech.Ego {

	public class HitscanProjectileTask : IProjectileTask, IProjectileTaskLifetime {
		public IProjectileArgs Args {
			get;
			set;
		}
		public Vector3 CurrentPosition => position;

		private Vector3 position;

		public HitscanProjectileTask(IProjectileArgs args) {
			Args = args;
			position = args.Origin;
		}

		public void Run() => Test();

		#region EVENT
		public event EventHandler<ImpactEventArgs> Impacted;
		public event EventHandler Launched;
		public event EventHandler Destroyed;
		#endregion

		#region PIPELINE
		private bool Test() {
			bool hasImpact = Physics.Raycast(Args.Origin, Args.Direction, out var hitInfo, Args.MaxDistance, Args.CollisionMask);
			if (hasImpact)
				position = hitInfo.point;
			else
				position = Args.Origin + Args.Direction * Args.MaxDistance;

			Launched?.Invoke(this, EventArgs.Empty);
			if (hasImpact) {
				var eventArgs = new ImpactEventArgs(hitInfo.point, hitInfo.normal, hitInfo.collider);
				Impacted?.Invoke(this, eventArgs);
			}

			Destroyed?.Invoke(this, EventArgs.Empty);

			return hasImpact;
		}
		#endregion
	}
}
