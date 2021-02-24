
namespace Andtech.Ego {

	public static class SpreadControllerExtensions {

		public static void Load(this SpreadController controller, SpreadProfile profile) {
			controller.AimSpeed = profile.AimSpeed;
			controller.UnfocusMin = profile.UnfocusMin;
			controller.UnfocusMax = profile.UnfocusMax;
			controller.UnfocusKickAmount = profile.UnfocusKickAmount;
			controller.UnfocusResetRate = profile.UnfocusResetRate;
			controller.FocusMin = profile.FocusMin;
			controller.FocusMax = profile.FocusMax;
			controller.FocusKickAmount = profile.FocusKickAmount;
			controller.FocusResetRate = profile.FocusResetRate;
			controller.Rebuild();
		}
	}
}
