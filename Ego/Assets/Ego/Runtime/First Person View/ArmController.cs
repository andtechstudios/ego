﻿using UnityEngine;

namespace Andtech.Ego
{

    public class ArmController : MonoBehaviour
    {
        public WeaponRig Rig
        {
            get => rig;
            set => rig = value;
        }
        public Vector3 RestingOffset
        {
            get;
            set;
        }

        [SerializeField]
        private WeaponRig rig;
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Transform restingPoint;
        [SerializeField]
        private Transform adsPoint;

        private bool isZoomedIn;
        private float alpha;
        private float speed;
        private float smoothTime = 0.05f;

        public void ZoomIn(float zoomTime = 0.25f)
        {
            isZoomedIn = true;
        }

        public void ZoomOut(float zoomTime = 0.25f)
        {
            isZoomedIn = false;
        }

        #region MONOBEHAVIOUR
        protected virtual void LateUpdate()
        {
            var position = isZoomedIn ? 1.0f : 0.0f;
            alpha = Mathf.SmoothDamp(alpha, position, ref speed, smoothTime);

            var restingPosition = restingPoint.localPosition - (rig.FrontHand.localPosition - rig.Root.localPosition) + RestingOffset;
            var aimingPosition = adsPoint.localPosition - (rig.RearSight.localPosition - rig.Root.localPosition);
            target.localPosition = Vector3.Lerp(restingPosition, aimingPosition, alpha);
        }
        #endregion
    }
}
