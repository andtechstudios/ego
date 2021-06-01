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

    public class MuzzleFlash : MonoBehaviour
    {
        public Transform FlashTransform
        {
            get => flashTransform;
            set => flashTransform = value;
        }
        public float Duration
        {
            get => duration;
            set => duration = value;
        }
        public Light Light
        {
            get => light;
            set => light = value;
        }

        [SerializeField]
        private Transform flashTransform;
        [SerializeField]
        private float duration;
        [SerializeField]
        private Light light;

        private bool EnableLight
        {
            set
            {
                if (light)
                    light.enabled = value;
            }
        }
        private float LightIntensity
        {
            set
            {
                if (light)
                    light.intensity = value;
            }
        }

        private float initialIntensity;

        public void Play()
        {
            EnableLight = true;
            flashTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
            StartCoroutine(Playing());
        }

        public void Stop()
        {
            flashTransform.localScale = Vector3.zero;
            EnableLight = false;
        }

        #region MONOBEHAVIOUR
        protected virtual void Start()
        {
            initialIntensity = light.intensity;
            Stop();
        }
        #endregion

        #region COROUTINE
        private IEnumerator Playing()
        {
            foreach (var alpha in Tween.Linear(duration))
            {
                flashTransform.localScale = Vector3.one * Mathf.Lerp(1.0f, 0.75f, alpha);
                LightIntensity = Mathf.Lerp(initialIntensity, 0.0f, alpha);
                yield return null;
            }
            flashTransform.localScale = Vector3.zero;
            EnableLight = false;
        }
        #endregion
    }
}
