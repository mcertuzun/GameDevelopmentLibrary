using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.Pooling
{
    public interface IPoolObject
    {
        void clearForRelease();

        void resetForRotate();
        void OnCreate();

    }
}