/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Ego
{

    public class FirstPersonView : MonoBehaviour
    {
        public ActionPoint ActionPoint => actionPoint;
        public ActionPointController ActionPointController => actionPointController;
        public Transform WorldCameraAnchor => worldCameraAnchor;
        public Transform FirstPersonCameraAnchor => firstPersonCameraAnchor;
        public Transform HandsAnchor => handsAnchor;

        [SerializeField]
        private ActionPoint actionPoint;
        [SerializeField]
        private ActionPointController actionPointController;
        [Header("Rig")]
        [SerializeField]
        private Transform worldCameraAnchor;
        [SerializeField]
        private Transform firstPersonCameraAnchor;
        [SerializeField]
        private Transform handsAnchor;
    }
}
