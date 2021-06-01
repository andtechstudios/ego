using UnityEngine;

namespace Andtech.Ego
{

    public class TracerManager : SubsystemObserver<SimpleDynamicsRuntime>
    {
        [SerializeField]
        private Tracer tracerPrefab;

        #region OVERRIDE
        protected override void OnRegister(SimpleDynamicsRuntime instance)
        {
            instance.ProjectileFactory.Initiated += HandleInitiated;
        }

        protected override void OnUnregister(SimpleDynamicsRuntime instance)
        {
            instance.ProjectileFactory.Initiated -= HandleInitiated;
        }
        #endregion

        #region CALLBACK
        private void HandleInitiated(object sender0, DynamicsFactoryEventArgs<IProjectileArgs, IProjectileTask> e0)
        {
            Tracer tracer = null;
            var args = e0.Args;
            var projectile = e0.Task;
            var lifetime = projectile as IProjectileTaskLifetime;
            if (lifetime != null)
            {
                lifetime.Launched += Lifetime_Launched;
                lifetime.Destroyed += Lifetime_Destroyed;
            }

            void Lifetime_Launched(object sender1, System.EventArgs e)
            {
                tracer = CreateTracer();
            }

            void Lifetime_Destroyed(object sender1, System.EventArgs e1)
            {
                lifetime.Launched -= Lifetime_Launched;
                lifetime.Destroyed -= Lifetime_Destroyed;
                tracer.StopTracking();
            }

            Tracer CreateTracer()
            {
                var t = Instantiate(tracerPrefab);
                Vector3 position;
                if (args is SimpleProjectileArgs sArgs)
                    position = sArgs.DisplayOrigin ?? Vector3.zero;
                else
                    position = args.Origin;
                var direction = args.Direction;

                t.Preset(position, args.Direction, () => projectile.CurrentPosition);

                return t;
            }
        }
        #endregion

        #region PIPELINE
        #endregion
    }
}
