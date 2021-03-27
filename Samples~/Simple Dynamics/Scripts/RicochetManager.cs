/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego {

	public class RicochetManager : SubsystemObserver<SimpleDynamicsRuntime> {
		[SerializeField]
		private GameObject ricochetPrefab;
		[SerializeField]
		private Transform folder;

		#region OVERRIDE
		protected override void OnRegister(SimpleDynamicsRuntime instance) {
			instance.ProjectileFactory.Initiated += HandleInitiated;
		}

		protected override void OnUnregister(SimpleDynamicsRuntime instance) {
			instance.ProjectileFactory.Initiated -= HandleInitiated;
		}
		#endregion

		#region CALLBACK
		private void HandleInitiated(object sender, DynamicsFactoryEventArgs<IProjectileArgs, IProjectileTask> e) {
			var projectile = e.Task;
			projectile.Impacted += Projectile_Impacted;
		}

		private void Projectile_Impacted(object sender, ImpactEventArgs e) {
			var projectile = sender as IProjectileTask;
			projectile.Impacted -= Projectile_Impacted;

			var go = Instantiate(ricochetPrefab, folder);
			go.transform.SetPositionAndRotation(e.Point, Quaternion.LookRotation(e.Normal));
		}
		#endregion
	}
}
