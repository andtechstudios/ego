using System;
using UnityEngine;

namespace Andtech.Ego
{

    public class Crosshair : MonoBehaviour
    {
        public Camera Camera
        {
            get => camera;
            set => camera = value;
        }
        public float Alpha
        {
            set => canvasGroup.alpha = value;
        }
        public Vector2 Scale
        {
            get;
            set;
        } = Vector2.one;
        public Func<Vector2> AngleStrategy { get; set; }
        public RectTransform Target => target;

        private RectTransform target;
        [SerializeField]
        private CanvasGroup canvasGroup;
        [SerializeField]
        private Camera camera;

        private float virtualDepth;

        #region MONOBEHAVIOUR
        protected virtual void Awake()
        {
            target = transform as RectTransform;
        }

        protected virtual void LateUpdate()
        {
            Rebuild();

            var range = AngleStrategy?.Invoke() ?? Vector2.zero;
            var width = virtualDepth * Mathf.Tan((range.x / 2.0f) * Mathf.Deg2Rad);
            var height = virtualDepth * Mathf.Tan((range.y / 2.0f) * Mathf.Deg2Rad);

            var sizeDelta = new Vector2(width, height);
            Target.sizeDelta = Vector2.Scale(sizeDelta, Scale);

            void Rebuild()
            {
                float angle = camera.fieldOfView / 2.0f;
                virtualDepth = Screen.height * (1.0f / Mathf.Tan(angle * Mathf.Deg2Rad));
            }
        }
        #endregion
    }
}
