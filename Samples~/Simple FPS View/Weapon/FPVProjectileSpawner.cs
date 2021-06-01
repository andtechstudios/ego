/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

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
