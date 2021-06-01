using System;
using UnityEngine;

namespace Andtech.Ego
{

    [Serializable]
    public struct FPVProjectileSpawner : IProjectileSpawner
    {
        public IProjectileArgs Args
        {
            get
            {
                args.Origin = actionPoint.Position;
                args.Direction = actionPoint.Sample() * Vector3.forward;
                args.DisplayOrigin = CameraUtility.TransformBetweenFOV(cameraFPV, cameraWorld, muzzle.position);

                return args;
            }
        }

        [SerializeField]
        private SimpleProjectileArgs args;
        [SerializeField]
        private ActionPoint actionPoint;
        [SerializeField]
        private Transform muzzle;

        [SerializeField]
        private Camera cameraFPV;
        [SerializeField]
        private Camera cameraWorld;
    }
}
