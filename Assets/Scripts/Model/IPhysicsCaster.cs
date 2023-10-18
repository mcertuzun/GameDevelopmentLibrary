using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.Model
{
    public interface IPhysicsCaster
    {
        bool isActive();
        void cast(Vector3 Origin, Vector3 Direction);
        List<ITarget> getTargets();


    }
}