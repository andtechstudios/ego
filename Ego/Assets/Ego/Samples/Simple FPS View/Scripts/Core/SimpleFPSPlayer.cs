using UnityEngine;

namespace Andtech.Ego {

	public class SimpleFPSPlayer : MonoBehaviour {
		public FirstPersonEffectSystem EffectSystem => effectSystem;
		public AimController AimController => aimController;
		public SpreadController SpreadController => spreadController;

		[SerializeField]
		private FirstPersonEffectSystem effectSystem;
		[SerializeField]
		private AimController aimController;
		[SerializeField]
		private SpreadController spreadController;
		[SerializeField]
		private ArmController armController;

		public void StartAim() {
			spreadController.Focus();
			armController.ZoomIn();
			aimController.StartAim();
		}

		public void StopAim() {
			spreadController.Unfocus();
			armController.ZoomOut();
			aimController.StopAim();
		}
	}
}
