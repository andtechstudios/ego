using UnityEngine;

namespace Andtech.Ego {

	public interface IPositionEffect {

		Vector3 GetPosition();
	}

	public interface IRotationEffect {

		Vector3 GetRotation();
	}

	public interface IScaleEffect {

		Vector3 GetScale();
	}
}
