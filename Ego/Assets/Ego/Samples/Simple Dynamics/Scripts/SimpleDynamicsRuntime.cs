namespace Andtech.Ego {

	public class SimpleDynamicsRuntime : SubsystemBehaviour<SimpleDynamicsRuntime> {
		public DynamicsFactory<IProjectileArgs, IProjectileTask> ProjectileFactory => projectileFactory;
		public DynamicsFactory<IExplosionArgs, IExplosionTask> ExplosionFactory => explosionFactory;

		private readonly DynamicsFactory<IProjectileArgs, IProjectileTask> projectileFactory = new DynamicsFactory<IProjectileArgs, IProjectileTask>();
		private readonly DynamicsFactory<IExplosionArgs, IExplosionTask> explosionFactory = new DynamicsFactory<IExplosionArgs, IExplosionTask>();

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			projectileFactory.Add(args => new HitscanProjectileTask(args));
		}
		#endregion
	}
}
