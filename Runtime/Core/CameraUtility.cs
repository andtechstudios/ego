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

    public static class CameraUtility
    {

        public static Vector3 TransformBetweenFOV(Camera cameraSource, Camera cameraDestination, Vector3 point)
        {
            var delta = point - cameraSource.transform.position;
            var h = delta.magnitude;
            var distance = h / (cameraDestination.fieldOfView / cameraSource.fieldOfView);

            var vp = cameraSource.WorldToViewportPoint(point);
            var rayB = cameraDestination.ViewportPointToRay(vp);

            return cameraDestination.transform.position + rayB.direction * distance;
        }
    }
}
