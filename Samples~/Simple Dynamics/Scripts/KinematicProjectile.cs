/*
 *	Copyright (c) 2020, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Collections;
using UnityEngine;

namespace Andtech.Ego {

	public class KinematicProjectile : MonoBehaviour, IProjectileTask, IProjectileTaskLifetime {
		public IProjectileArgs Args {
			get;
			set;
		}
		public Vector3 CurrentPosition => Position;

		[SerializeField]
		private Transform target;
		private SimpleProjectileArgs args;

		private Vector3 Position {
			get => target.position;
			set {
				target.position = value;
			}
		}

		public void Link(SimpleProjectileArgs args) {
			this.args = args;
			Position = args.Origin;
		}

		public void Run() {
			StartCoroutine(Moving());
		}

		#region COROUTINE
		private IEnumerator Moving() {
			var velocity = args.Direction * args.Speed;

			var distanceLimit = args.MaxDistance;
			var distanceCounter = 0.0F;
			while (enabled) {
				var step = velocity * Time.deltaTime;
				var position = Position;
				var nextPosition = position + step;

				var hasHit = Physics.Linecast(position, nextPosition, out var hitInfo, args.CollisionMask);
				if (hasHit)
					nextPosition = hitInfo.point;
				var hasMiss = (distanceCounter += step.magnitude).CompareTo(distanceLimit) >= 0;
				Position = nextPosition;

				if (hasHit || hasMiss) {
					// Raise pooling events before projectile events
					RequestedReclaim?.Invoke(this, EventArgs.Empty);
					if (hasHit)
						Impacted?.Invoke(this, new ImpactEventArgs(hitInfo.point, hitInfo.normal, hitInfo.collider));
					Destroyed?.Invoke(this, EventArgs.Empty);
					break;
				}

				yield return null;
			}
		}
		#endregion

		#region EVENT
		public event EventHandler<ImpactEventArgs> Impacted;
		public event EventHandler Launched;
		public event EventHandler Destroyed;
		public event EventHandler RequestedReclaim;
		#endregion
	}
}
