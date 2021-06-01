using UnityEngine;

namespace Andtech.Ego
{

    public class WeaponRig : MonoBehaviour
    {
        public Transform Root => root;
        public Transform RearHand => rearHand;
        public Transform FrontHand => frontHand;
        public Transform RearSight => rearSight;
        public Transform FrontSight => frontSight;
        public Transform Muzzle => muzzle;

        [SerializeField]
        private Transform root;
        [SerializeField]
        private Transform rearHand;
        [SerializeField]
        private Transform frontHand;
        [SerializeField]
        private Transform rearSight;
        [SerializeField]
        private Transform frontSight;
        [SerializeField]
        private Transform muzzle;
    }
}
