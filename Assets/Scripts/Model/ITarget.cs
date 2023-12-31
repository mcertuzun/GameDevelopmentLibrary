﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.Model
{
    public interface ITarget
    {
        Vector3 getObjectPosition();
        Vector3 getTargetPosition();

        GameObject GetGameObject();

        bool isValid();


    }
}