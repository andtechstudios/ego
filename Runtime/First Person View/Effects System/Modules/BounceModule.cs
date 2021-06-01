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
    public class BounceModule : EffectModule, IPositionEffect, IRotationEffect
    {
        public Vector3 OffsetPosition
        {
            get => calculator.OffsetPosition;
            set => calculator.OffsetPosition = value;
        }
        public Vector3 OffsetRotation
        {
            get => calculator.OffsetRotation;
            set => calculator.OffsetRotation = value;
        }
        public float ResetDuration
        {
            get => calculator.ResetDuration;
            set => calculator.ResetDuration = value;
        }
        public float SmoothTime
        {
            get => calculator.SmoothTime;
            set => calculator.SmoothTime = value;
        }

        [SerializeField]
        private BounceCalculator calculator;

        private Coroutine coroutine;

        public void SetBouncePosition(float value)
        {
            calculator.SetBouncePosition(value);
        }

        public Coroutine Play(float amount)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }

            coroutine = StartCoroutine?.Invoke(calculator.Bouncing(amount));

            return coroutine;
        }

        #region INTERFACE
        [TransformEffect(FirstPersonViewAnchor.Arms)]
        Vector3 IPositionEffect.GetPosition() => calculator.GetPosition();

        [TransformEffect(FirstPersonViewAnchor.Arms)]
        Vector3 IRotationEffect.GetRotation() => calculator.GetRotation();
        #endregion
    }
}
