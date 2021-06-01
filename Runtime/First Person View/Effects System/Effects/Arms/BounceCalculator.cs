/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Collections;
using UnityEngine;

namespace Andtech.Ego
{

    [Serializable]
    public class BounceCalculator
    {
        public Vector3 OffsetPosition
        {
            get => offsetPosition;
            set => offsetPosition = value;
        }
        public Vector3 OffsetRotation
        {
            get => offsetRotation;
            set => offsetRotation = value;
        }
        public float ResetDuration
        {
            get => resetDuration;
            set => resetDuration = value;
        }
        public float SmoothTime
        {
            get => smoothTime;
            set => smoothTime = value;
        }

        [SerializeField]
        private Vector3 offsetPosition = new Vector3(0.0f, -0.125f, 0.0f);
        [SerializeField]
        private Vector3 offsetRotation = new Vector3(0.0f, 0.0f, 30.0f);
        [SerializeField]
        private float resetDuration = 0.333f;
        [SerializeField]
        private float smoothTime = 0.125f;

        private readonly FloatInterpolator bouncePosition = FloatInterpolator.Smooth(1.0f);

        public void SetBouncePosition(float target)
        {
            bouncePosition.Target = target;
        }

        public IEnumerator Bouncing(float target)
        {
            foreach (var alpha in Tween.Linear(resetDuration))
            {
                bouncePosition.Target = Mathf.Lerp(target, 0.0f, alpha);
                yield return null;
            }
        }

        public Vector3 GetPosition()
        {
            bouncePosition.SmoothTime = smoothTime;
            bouncePosition.SmoothDamp();

            return Vector3.LerpUnclamped(Vector3.zero, offsetPosition, bouncePosition.Current);
        }

        public Vector3 GetRotation() => Vector3.Lerp(Vector3.zero, offsetRotation, bouncePosition.Current);
    }
}
