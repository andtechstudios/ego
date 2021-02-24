using UnityEngine;

namespace Andtech.Ego {

	public class SimpleFPSPlayerDemo : MonoBehaviour {
		public SpreadController spreadController;
		public SpreadProfile spreadProfile;
		public Crosshair crosshair;

		void Start() {
			spreadController.Load(spreadProfile);
			crosshair.Link(spreadController.ActionPoint);
		}
	}
}
