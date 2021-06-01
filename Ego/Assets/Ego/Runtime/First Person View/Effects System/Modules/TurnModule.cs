using System;
using UnityEngine;

namespace Andtech.Ego
{

    [Serializable]
    public class TurnModule : EffectModule, IRotationEffect
    {
        public Transform Source
        {
            get => calculator.Source;
            set => calculator.Source = value;
        }
        public float MaxAngularSpeed
        {
            get => calculator.MaxAngularSpeed;
            set => calculator.MaxAngularSpeed = value;
        }
        public float AngleOffset
        {
            get => calculator.AngleOffset;
            set => calculator.AngleOffset = value;
        }
        public float SmoothTime
        {
            get => calculator.SmoothTime;
            set => calculator.SmoothTime = value;
        }

        [SerializeField]
        private TurnCalculator calculator;

        #region INTERFACE
        [TransformEffect(FirstPersonViewAnchor.Hand)]
        Vector3 IRotationEffect.GetRotation() => calculator.GetTurnRotation();
        #endregion
    }
}
