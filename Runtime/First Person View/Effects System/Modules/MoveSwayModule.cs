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
    public class MoveSwayModule : EffectModule, IPositionEffect
    {
        public float Intensity
        {
            get => intensity;
            set => intensity = value;
        }
        public float Period
        {
            get => calculator.Period;
            set => calculator.Period = value;
        }
        public float LateralAmplitude
        {
            get => calculator.LateralAmplitude;
            set => calculator.LateralAmplitude = value;
        }
        public float VerticalAmplitude
        {
            get => calculator.VerticalAmplitude;
            set => calculator.VerticalAmplitude = value;
        }

        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float intensity;
        [SerializeField]
        private MoveSwayCalculator calculator;

        #region INTERFACE
        [TransformEffect(FirstPersonViewAnchor.Arms)]
        Vector3 IPositionEffect.GetPosition() => intensity * calculator.GetSwayPosition(Time.time);
        #endregion
    }
}
