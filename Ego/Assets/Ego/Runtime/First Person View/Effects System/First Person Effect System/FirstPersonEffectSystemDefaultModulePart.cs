using UnityEngine;

namespace Andtech.Ego
{

    public partial class FirstPersonEffectSystem
    {
        public CameraBobModule CameraBobModule => cameraBobModule;
        public CameraShakeModule CameraShakeModule => cameraShakeModule;
        public ViewKickModule ViewKickModule => viewKickModule;
        public BreathModule BreathModule => breathModule;
        public TurnModule TurnModule => turnModule;
        public BounceModule BounceModule => bounceModule;
        public MoveSwayModule MoveSwayModule => moveSwayModule;
        public WeaponKickModule WeaponKickModule => weaponKickModule;

        [Header("Camera Effects")]
        [SerializeField]
        private CameraBobModule cameraBobModule;
        [SerializeField]
        private CameraShakeModule cameraShakeModule;
        [SerializeField]
        private ViewKickModule viewKickModule;
        [Header("Arms Effects")]
        [SerializeField]
        private BreathModule breathModule;
        [SerializeField]
        private TurnModule turnModule;
        [SerializeField]
        private BounceModule bounceModule;
        [SerializeField]
        private MoveSwayModule moveSwayModule;
        [SerializeField]
        private WeaponKickModule weaponKickModule;
    }
}
