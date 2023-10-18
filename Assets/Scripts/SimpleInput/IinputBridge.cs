using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.SimpleInput
{
    public interface IinputBridge
    {
        Vector3 moveInput { get; }
        void setMinThreshhold(float value);


    }
}