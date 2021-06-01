/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Collections;
using UnityEngine;

namespace Andtech.Ego
{

    public class AimController : MonoBehaviour
    {
        [SerializeField]
        private FirstPersonEffectSystem effectSystem;
        [SerializeField]
        private Camera camera;
        [SerializeField]
        private float fovZoomedIn = 60;
        [SerializeField]
        private Crosshair crosshair;
        [SerializeField]
        private bool alwaysShowCrosshair;

        private float fovResting;
        private float weight;

        /// <summary>
        /// The control parameter
        ///		0: fully zoomed out
        ///		1: fully zoomed in
        /// </summary>
        public float Weight
        {
            get => weight;
            set
            {
                weight = value;

                camera.fieldOfView = Mathf.Lerp(fovResting, fovZoomedIn, weight);
                effectSystem.TurnModule.Weight = Mathf.Lerp(1.0f, 0.1f, weight);
                effectSystem.MoveSwayModule.Weight = Mathf.Lerp(1.0f, 0.1f, weight);
                effectSystem.WeaponKickModule.Weight = Mathf.Lerp(1.0f, 0.7f, weight);
                effectSystem.BreathModule.Weight = Mathf.Lerp(1.0f, 0.1f, weight);
                effectSystem.BounceModule.Weight = Mathf.Lerp(1.0f, 0.5f, weight);
                effectSystem.CameraShakeModule.Weight = Mathf.Lerp(1.0f, 0.666f, weight);

                crosshair.Alpha = alwaysShowCrosshair ? 1.0f : (1.0f - weight);
                crosshair.Scale = alwaysShowCrosshair ? Vector2.one : Vector2.one * (1.0f - weight);
            }
        }

        public void StartAim()
        {
            StopAllCoroutines();
            StartCoroutine(Changing(1.0f));
        }

        public void StopAim()
        {
            StopAllCoroutines();
            StartCoroutine(Changing(0.0f));
        }

        #region MONOBEHAVIOUR
        protected virtual void OnEnable()
        {
            fovResting = camera.fieldOfView;
        }
        #endregion

        #region COROUTINE
        private IEnumerator Changing(float value)
        {
            float duration = 0.125f;
            float initial = Weight;
            foreach (var alpha in Tween.Linear(duration))
            {
                Weight = Mathf.Lerp(initial, value, alpha);
                yield return null;
            }
        }
        #endregion
    }
}
