using UnityEngine;

namespace Andtech.Ego {

	public interface IExplosionArgs {
		Vector3 Position { get; }
		float Radius { get; }
		LayerMask CollisionMask { get; }
	}
}
