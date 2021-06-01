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
    public struct SimpleProjectileArgs : IProjectileArgs
    {
        public Vector3 Origin { get; set; }
        public Vector3 Direction { get; set; }
        public Vector3? DisplayOrigin { get; set; }
        public LayerMask CollisionMask
        {
            get => collisionMask;
            set => collisionMask = value;
        }
        public float Speed
        {
            get => speed;
            set => speed = value;
        }
        public float Damage { get; set; }
        public float MaxDistance
        {
            get => maxDistance;
            set => maxDistance = value;
        }

        [SerializeField]
        private LayerMask collisionMask;
        [SerializeField]
        private float maxDistance;
        [SerializeField]
        private float speed;
    }
}
