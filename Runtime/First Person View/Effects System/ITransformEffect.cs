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

    public interface IPositionEffect
    {

        Vector3 GetPosition();
    }

    public interface IRotationEffect
    {

        Vector3 GetRotation();
    }

    public interface IScaleEffect
    {

        Vector3 GetScale();
    }
}
