using System.Collections;
using UnityEngine;

namespace Andtech.Ego {

	public class Hitmarker : MonoBehaviour {
		public float DisplayTime {
			get => displayTime;
			set => displayTime = value;
		}

		[SerializeField]
		private CanvasGroup canvasGroup;
		[SerializeField]
		private float displayTime;

		public void Show() {
			StopAllCoroutines();
			StartCoroutine(Showing());
		}

		public void Hide() {
			StopAllCoroutines();
			canvasGroup.alpha = 0.0F;
		}

		#region MONOBEHAVIOUR
		protected virtual void Start() {
			Hide();
		}
		#endregion

		#region COROUTINE
		private IEnumerator Showing() {
			canvasGroup.alpha = 1.0F;
			foreach (var alpha in Tween.EaseOutPow(displayTime, 2.666F)) {
				transform.localScale = Vector3.Lerp(1.5F * Vector3.one, Vector3.one, alpha);
				yield return null;
			}
			canvasGroup.alpha = 0.0F;
		}
		#endregion
	}
}
