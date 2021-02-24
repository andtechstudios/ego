using UnityEngine;

namespace Andtech.Ego {

	public interface IProjectileArgs {
		Vector3 Origin { get; }
		Vector3 Direction { get; }
		LayerMask CollisionMask { get; }
		float MaxDistance { get; }
		float Speed { get; }
	}
}
