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
    public class MoveSwayCalculator
    {
        public float Period
        {
            get => period;
            set => period = value;
        }
        public float LateralAmplitude
        {
            get => lateralAmplitude;
            set => lateralAmplitude = value;
        }
        public float VerticalAmplitude
        {
            get => verticalAmplitude;
            set => verticalAmplitude = value;
        }

        [SerializeField]
        private float period = 2.0f;
        [SerializeField]
        private float lateralAmplitude = 0.005f;
        [SerializeField]
        private float verticalAmplitude = 0.005f;

        public Vector3 GetSwayPosition(float t)
        {
            var amplitudeX = lateralAmplitude;
            var amplitudeY = verticalAmplitude;
            var x = amplitudeX * (2.0f * Mathf.PingPong(t, (period / 2.0f)) / (period / 2.0f) - 1.0f);
            var y = amplitudeY * -Mathf.Abs(Mathf.Sin(t / period * (2.0f * Mathf.PI)));

            return new Vector3(x, y, 0.0f);
        }
    }
}
