using System.Collections;
using UnityEngine;

namespace Andtech.Ego {

	public class AimController : MonoBehaviour {
		[SerializeField]
		private FirstPersonEffectSystem effectSystem;
		[SerializeField]
		private Camera camera;
		[SerializeField]
		private float fovZoomedIn = 60;
		[SerializeField]
		private Crosshair crosshair;
		[SerializeField]
		private bool alwaysShowCrosshair;

		private float fovResting;
		private float weight;

		/// <summary>
		/// The control parameter
		///		0: fully zoomed out
		///		1: fully zoomed in
		/// </summary>
		public float Weight {
			get => weight;
			set {
				weight = value;

				camera.fieldOfView = Mathf.Lerp(fovResting, fovZoomedIn, weight);
				effectSystem.TurnModule.Weight = Mathf.Lerp(1.0F, 0.1F, weight);
				effectSystem.MoveSwayModule.Weight = Mathf.Lerp(1.0F, 0.1F, weight);
				effectSystem.WeaponKickModule.Weight = Mathf.Lerp(1.0F, 0.7F, weight);
				effectSystem.BreathModule.Weight = Mathf.Lerp(1.0F, 0.1F, weight);
				effectSystem.BounceModule.Weight = Mathf.Lerp(1.0F, 0.5F, weight);
				effectSystem.CameraShakeModule.Weight = Mathf.Lerp(1.0F, 0.666F, weight);

				crosshair.Alpha = alwaysShowCrosshair ? 1.0F : (1.0F - weight);
				crosshair.Scale = alwaysShowCrosshair ? Vector2.one : Vector2.one * (1.0F - weight);
			}
		}

		public void StartAim() {
			StopAllCoroutines();
			StartCoroutine(Changing(1.0F));
		}

		public void StopAim() {
			StopAllCoroutines();
			StartCoroutine(Changing(0.0F));
		}

		#region MONOBEHAVIOUR
		protected virtual void OnEnable() {
			fovResting = camera.fieldOfView;
		}
		#endregion

		#region COROUTINE
		private IEnumerator Changing(float value) {
			float duration = 0.125F;
			float initial = Weight;
			foreach (var alpha in Tween.Linear(duration)) {
				Weight = Mathf.Lerp(initial, value, alpha);
				yield return null;
			}
		}
		#endregion
	}
}
