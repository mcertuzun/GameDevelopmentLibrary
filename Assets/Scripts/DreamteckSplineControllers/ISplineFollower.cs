﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.DreamteckSplineControllers
{
    public interface ISplineFollower
    {

        float followSpeed { get; }
        float horizontalSpeed { get; }
        float horizontalDistance { get; }

        float MaxRotation { get; }
        float RotationSpeed { get; }
        float HorizontalMovementLerp { get; }
        float RotationLerp { get; }
        bool isStopped { get; }

    }
}