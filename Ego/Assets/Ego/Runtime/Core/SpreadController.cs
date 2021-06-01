using System.Collections;
using UnityEngine;

namespace Andtech.Ego
{

    public class SpreadController : MonoBehaviour
    {
        public ActionPoint ActionPoint => actionPoint;
        public Vector2 UnfocusMin { get; set; }
        public Vector2 UnfocusMax { get; set; }
        public Vector2 UnfocusKickAmount { get; set; }
        public float UnfocusResetRate { get; set; }
        public float AimSpeed { get; set; }
        public Vector2 FocusMin { get; set; }
        public Vector2 FocusMax { get; set; }
        public Vector2 FocusKickAmount { get; set; }
        public float FocusResetRate { get; set; }

        [SerializeField]
        private ActionPoint actionPoint;
        private ActionPointController actionPointController;
        private float aimPosition;

        public void Kick()
        {
            var kickAmount = Vector2.Lerp(UnfocusKickAmount, FocusKickAmount, aimPosition);
            actionPointController.Add(kickAmount);
        }

        public void Focus()
        {
            StopAllCoroutines();
            StartCoroutine(Moving(1.0f));
        }

        public void Unfocus()
        {
            StopAllCoroutines();
            StartCoroutine(Moving(0.0f));
        }

        public void Rebuild()
        {
            actionPointController.MinRange = Vector2.Lerp(UnfocusMin, FocusMin, aimPosition);
            actionPointController.MaxRange = Vector2.Lerp(UnfocusMax, FocusMax, aimPosition);
            actionPointController.ResetRate = Mathf.Lerp(UnfocusResetRate, FocusResetRate, aimPosition);
        }

        #region MONOBEHAVIOUR
        protected virtual void Awake()
        {
            actionPointController = new ActionPointController(actionPoint);
        }

        protected virtual void OnEnable()
        {
            Rebuild();
        }

        protected virtual void Update()
        {
            actionPointController.Move();
        }
        #endregion

        #region COROUTINE
        private IEnumerator Moving(float to)
        {
            var from = aimPosition;
            var duration = Mathf.Abs(to - from) / AimSpeed;
            foreach (var t in Tween.Linear(duration))
            {
                aimPosition = Mathf.Lerp(from, to, t);
                Rebuild();

                yield return null;
            }
        }
        #endregion
    }
}
