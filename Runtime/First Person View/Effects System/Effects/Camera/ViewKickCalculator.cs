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
using static UnityEngine.ParticleSystem;

namespace Andtech.Ego
{

    [Serializable]
    public class ViewKickCalculator
    {
        public MinMaxCurve VerticalRecoilCurve
        {
            get => verticalRecoilCurve;
            set => verticalRecoilCurve = value;
        }
        public MinMaxCurve LateralRecoilCurve
        {
            get => lateralRecoilCurve;
            set => lateralRecoilCurve = value;
        }
        public Vector2 Range
        {
            get => range;
            set => range = value;
        }
        public float SmoothTime
        {
            get => smoothTime;
            set => smoothTime = value;
        }

        [SerializeField]
        private MinMaxCurve verticalRecoilCurve;
        [SerializeField]
        private MinMaxCurve lateralRecoilCurve;
        [SerializeField]
        private Vector2 range = new Vector2(6.0f, 8.0f);

        [SerializeField]
        private float centerSpeed = 32.0f;
        [SerializeField]
        private float smoothTime = 0.125f;

        private Vector3Interpolator interpolator = Vector3Interpolator.Smooth(1.0f);

        public IEnumerator Play(float amount)
        {
            var alpha = Mathf.Clamp01(interpolator.Current.y / range.y);

            var verticalIncrement = verticalRecoilCurve.Evaluate(alpha, UnityEngine.Random.value);
            var lateralIncrement = lateralRecoilCurve.Evaluate(alpha, UnityEngine.Random.value);

            var target = interpolator.Current;
            target.x += lateralIncrement;
            target.y += verticalIncrement;

            yield return Kicking(target);
        }

        public Vector3 GetKickRotation()
        {
            interpolator.SmoothTime = SmoothTime;
            interpolator.SmoothDamp();
            var position = new Vector2
            {
                x = Mathf.Clamp(interpolator.Current.x, -range.x, range.x),
                y = Mathf.Clamp(interpolator.Current.y, -range.y, range.y)
            };
            interpolator.Current = position;

            return new Vector3
            {
                x = -position.y,
                y = position.x
            };
        }

        #region COROUTINE
        private IEnumerator Kicking(Vector2 target)
        {
            var clampedTarget = target;
            var clampedPosition = interpolator.Current;

            foreach (var alpha in Tween.Linear(clampedTarget.magnitude / centerSpeed))
            {
                interpolator.Target = Vector3.Lerp(target, Vector3.zero, alpha);
                interpolator.SmoothTime = 1.0f / centerSpeed;
                yield return null;
            }
        }
        #endregion
    }
}
