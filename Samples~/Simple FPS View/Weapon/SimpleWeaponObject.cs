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

namespace Andtech.Ego.CombatSystem {

	public class ProjectileSpawnEventArgs : EventArgs {
		public IProjectileTask task;
	}

	public class SimpleWeaponObject : BaseWeaponObject {
		[SerializeField]
		private float rateOfFire;
		[SerializeField]
		private FPVProjectileSpawner projectileSpawner;
		[SerializeField]
		private MuzzleFlash flash;
		[SerializeField]
		private AudioSource audioSource;
		[SerializeField]
		private SimpleFPSPlayer player;

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			this.Attacked += Attacked;

			void Attacked(object sender, System.EventArgs e) {
				player.SpreadController.Kick();

				player.EffectSystem.ViewKickModule.Play();
				player.EffectSystem.CameraShakeModule.Play();
				player.EffectSystem.WeaponKickModule.Play();
			}
		}

		protected virtual void Update() {
			if (Input.GetMouseButtonDown(0)) {
				StartAttack();
			}
			else if (Input.GetMouseButtonUp(0)) {
				StopAttack();
			}
			if (Input.GetMouseButtonDown(1)) {
				player.StartAim();
			}
			else if (Input.GetMouseButtonUp(1)) {
				player.StopAim();
			}
		}
		#endregion

		#region OVERRIDE
		public override void StartAttack() {
			StopAllCoroutines();
			StartCoroutine(Firing());
		}

		public override void StopAttack() {
			StopAllCoroutines();
		}
		#endregion

		#region COROUTINE
		private IEnumerator Firing() {
			while (enabled) {
				yield return new WaitForEndOfFrame();
				Fire();

				var counter = rateOfFire;
				do {
					yield return new WaitForFixedUpdate();
				}
				while ((counter -= Time.fixedDeltaTime) > 0.0F);
			}
		}
		#endregion

		#region PIPELINE
		private void Fire() {
			var projectile = SimpleDynamicsRuntime.Instance.ProjectileFactory.Initiate<HitscanProjectileTask>(projectileSpawner.Args);
			projectile.Launched += Projectile_Launched;
			projectile.Run();
		}

		private void Projectile_Launched(object sender, EventArgs e) {
			OnAttack(new ProjectileSpawnEventArgs { task = sender as IProjectileTask });

			flash.Play();
			audioSource.Play();
		}
		#endregion
	}
}
