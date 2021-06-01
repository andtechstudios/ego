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
    public class KickCalculator
    {
        public float WindupDuration
        {
            get => windupDuration;
            set => windupDuration = value;
        }
        public float ResetSpeed
        {
            get => resetSpeed;
            set => resetSpeed = value;
        }
        public Vector3 MaxKickOffset
        {
            get => maxKickOffset;
            set => maxKickOffset = value;
        }
        public Vector3 MaxKickEulerAngles
        {
            get => maxKickEulerAngles;
            set => maxKickEulerAngles = value;
        }

        [SerializeField]
        private float windupDuration = 0.0085f;
        [SerializeField]
        private float resetSpeed = 0.25f;
        [SerializeField]
        private Vector3 maxKickOffset = new Vector3(0.0f, 0.0f, -0.1f);
        [SerializeField]
        private Vector3 maxKickEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

        private float kickAlpha;

        private Vector3 targetPosition;
        private Vector3 targetEulerAngles;

        public IEnumerator Play()
        {
            targetPosition.x = UnityEngine.Random.Range(-MaxKickOffset.x, MaxKickOffset.x);
            targetPosition.y = UnityEngine.Random.Range(-MaxKickOffset.y, MaxKickOffset.y);
            targetPosition.z = MaxKickOffset.z;
            targetEulerAngles.x = MaxKickEulerAngles.x;
            targetEulerAngles.y = MaxKickEulerAngles.y;
            targetEulerAngles.z = MaxKickEulerAngles.z;

            return Kicking();
        }

        public Vector3 GetKickPosition() => targetPosition * kickAlpha;

        public Vector3 GetKickRotation() => targetEulerAngles * kickAlpha;

        #region COROUTINE
        private IEnumerator Kicking()
        {
            foreach (float alpha in Tween.Linear(windupDuration))
            {
                kickAlpha = Mathf.Lerp(0.0f, 1.0f, alpha);
                yield return null;
            }

            foreach (float alpha in Tween.EaseOutQuadratic(resetSpeed))
            {
                kickAlpha = Mathf.Lerp(1.0f, 0.0f, alpha);
                yield return null;
            }
        }
        #endregion
    }
}
