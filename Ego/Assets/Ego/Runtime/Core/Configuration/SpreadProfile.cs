using UnityEngine;

namespace Andtech.Ego
{

    [CreateAssetMenu(fileName = "Spread Profile", menuName = "Andtech/Ego/Spread Profile", order = 99)]
    public class SpreadProfile : ScriptableObject
    {
        public float AimSpeed => aimSpeed;
        public Vector2 UnfocusMin => unfocusMin;
        public Vector2 UnfocusMax => unfocusMax;
        public Vector2 UnfocusKickAmount => unfocusKickAmount;
        public float UnfocusResetRate => unfocusResetRate;
        public Vector2 FocusMin => focusMin;
        public Vector2 FocusMax => focusMax;
        public Vector2 FocusKickAmount => focusKickAmount;
        public float FocusResetRate => focusResetRate;

        [SerializeField]
        private float aimSpeed = 8.0f;

        [Header("Unfocused Parameters")]
        [SerializeField]
        private Vector2 unfocusMin = new Vector2(6.0f, 6.0f);
        [SerializeField]
        private Vector2 unfocusMax = new Vector2(30.0f, 30.0f);
        [SerializeField]
        private Vector2 unfocusKickAmount = new Vector2(8.0f, 8.0f);
        [SerializeField]
        private float unfocusResetRate = 64.0f;

        [Header("Focused Parameters")]
        [SerializeField]
        private Vector2 focusMin = new Vector2(0.0f, 0.0f);
        [SerializeField]
        private Vector2 focusMax = new Vector2(3.0f, 3.0f);
        [SerializeField]
        private Vector2 focusKickAmount = new Vector2(2.5f, 2.5f);
        [SerializeField]
        private float focusResetRate = 24.0f;
    }
}
