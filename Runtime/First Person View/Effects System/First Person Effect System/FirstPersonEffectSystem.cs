/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego
{

    public partial class FirstPersonEffectSystem : MonoBehaviour
    {
        public Transform CameraWorldAnchor
        {
            get => cameraWorldAnchor;
            set => cameraWorldAnchor = value;
        }
        public Transform CameraFirstPersonAnchor
        {
            get => cameraFirstPersonAnchor;
            set => cameraFirstPersonAnchor = value;
        }
        public Transform ArmsAnchor
        {
            get => armsAnchor;
            set => armsAnchor = value;
        }
        public Transform HandAnchor
        {
            get => handAnchor;
            set => handAnchor = value;
        }

        [Header("Anchors")]
        [SerializeField]
        private Transform cameraWorldAnchor;
        [SerializeField]
        private Transform cameraFirstPersonAnchor;
        [SerializeField]
        private Transform armsAnchor;
        [SerializeField]
        private Transform handAnchor;

        #region MONOBEHAVIOUR
        private void Awake()
        {
            LoadModules();
        }

        private void LateUpdate()
        {
            cameraWorldAnchor.localPosition = Vector3.zero;
            cameraWorldAnchor.localEulerAngles = Vector3.zero;
            cameraWorldAnchor.localScale = Vector3.one;
            cameraFirstPersonAnchor.localPosition = Vector3.zero;
            cameraFirstPersonAnchor.localEulerAngles = Vector3.zero;
            cameraFirstPersonAnchor.localScale = Vector3.one;
            armsAnchor.localPosition = Vector3.zero;
            armsAnchor.localEulerAngles = Vector3.zero;
            armsAnchor.localScale = Vector3.one;
            //handAnchor.localPosition = Vector3.zero;
            handAnchor.localEulerAngles = Vector3.zero;
            //handAnchor.localScale = Vector3.one;

            for (int i = 0; i < manifests.Count; i++)
            {
                var manifest = manifests[i];
                if (!manifest.Module.Enabled)
                    continue;

                Transform transform;
                switch (manifest.Anchor)
                {
                    case FirstPersonViewAnchor.CameraWorld:
                        transform = cameraWorldAnchor;
                        break;
                    case FirstPersonViewAnchor.CameraFirstPersonView:
                        transform = cameraFirstPersonAnchor;
                        break;
                    case FirstPersonViewAnchor.Arms:
                        transform = armsAnchor;
                        break;
                    case FirstPersonViewAnchor.Hand:
                        transform = handAnchor;
                        break;
                    default:
                        transform = cameraWorldAnchor;
                        break;
                }
                var vector = manifest.Module.Weight * manifest.Function();

                switch (manifest.Component)
                {
                    case TransformComponent.Position:
                        transform.localPosition += vector;
                        break;
                    case TransformComponent.Rotation:
                        transform.localEulerAngles += vector;
                        break;
                    case TransformComponent.Scale:
                        transform.localScale += vector;
                        break;
                }
            }
        }
        #endregion
    }
}
