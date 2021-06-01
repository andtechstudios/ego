using System;
using UnityEngine;

namespace Andtech.Ego
{

    [Serializable]
    public class WeaponKickModule : EffectModule, IPositionEffect, IRotationEffect
    {
        public float WindupDuration
        {
            get => calculator.WindupDuration;
            set => calculator.WindupDuration = value;
        }
        public float ResetSpeed
        {
            get => calculator.ResetSpeed;
            set => calculator.ResetSpeed = value;
        }
        public Vector3 MaxKickOffset
        {
            get => calculator.MaxKickOffset;
            set => calculator.MaxKickOffset = value;
        }
        public Vector3 MaxKickEulerAngles
        {
            get => calculator.MaxKickEulerAngles;
            set => calculator.MaxKickEulerAngles = value;
        }

        [SerializeField]
        private KickCalculator calculator;

        private Coroutine coroutine;

        public Coroutine Play()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }

            coroutine = StartCoroutine?.Invoke(calculator.Play());

            return coroutine;
        }

        #region INTERFACE
        [TransformEffect(FirstPersonViewAnchor.Arms)]
        Vector3 IPositionEffect.GetPosition() => calculator.GetKickPosition();

        [TransformEffect(FirstPersonViewAnchor.Hand)]
        Vector3 IRotationEffect.GetRotation() => calculator.GetKickRotation();
        #endregion
    }
}
