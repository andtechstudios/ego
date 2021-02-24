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
