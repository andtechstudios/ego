using System;
using UnityEngine;

namespace Andtech.Ego
{

    [Serializable]
    public class BreathModule : EffectModule, IPositionEffect
    {
        public float Period
        {
            get => calculator.Period;
            set => calculator.Period = value;
        }
        public float HorizontalAmplitude
        {
            get => calculator.HorizontalAmplitude;
            set => calculator.HorizontalAmplitude = value;
        }
        public float VerticalAmplitude
        {
            get => calculator.VerticalAmplitude;
            set => calculator.VerticalAmplitude = value;
        }

        [SerializeField]
        private BreathCalculator calculator;

        #region INTERFACE
        [TransformEffect(FirstPersonViewAnchor.Arms)]
        Vector3 IPositionEffect.GetPosition() => calculator.GetBreathPosition(Time.time);
        #endregion
    }
}
