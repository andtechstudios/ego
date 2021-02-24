using System;
using UnityEngine;

namespace Andtech.Ego.CombatSystem {

	public abstract class BaseWeaponObject : MonoBehaviour {

		#region VIRTUAL
		public virtual void StartAttack() { }

		public virtual void StopAttack() { }
		#endregion

		#region EVENT
		public event EventHandler Attacked;
		public event EventHandler Failed;

		protected virtual void OnAttack(EventArgs e) => Attacked?.Invoke(this, e);

		protected virtual void OnFail(EventArgs e) => Failed?.Invoke(this, e);
		#endregion
	}
}
