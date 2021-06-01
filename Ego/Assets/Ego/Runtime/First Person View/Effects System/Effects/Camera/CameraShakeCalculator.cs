﻿using System;
using UnityEngine;

namespace Andtech.Ego
{

    [Serializable]
    public class CameraShakeCalculator
    {
        public float Speed
        {
            get => speed;
            set => speed = value;
        }
        public float Offset
        {
            get => offset;
            set => offset = value;
        }
        public float ResetSpeed
        {
            get => resetSpeed;
            set => resetSpeed = value;
        }

        [SerializeField]
        private float speed = 24.0f;
        [SerializeField]
        private float offset = 1.0f;
        [SerializeField]
        private float resetSpeed = 4.0f;

        public Vector3 GetShakePosition(float t)
        {
            return new Vector3
            {
                x = offset * PerlinNoise01(0.0f, speed * t),
                y = offset * PerlinNoise01(1.0f, speed * t),
                z = offset * PerlinNoise01(2.0f, speed * t),
            };

            float PerlinNoise01(float x, float y) => Mathf.PerlinNoise(x, y) * 2.0f - 1.0f;
        }
    }
}
