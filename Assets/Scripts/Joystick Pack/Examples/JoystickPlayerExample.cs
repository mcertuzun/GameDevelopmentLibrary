﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Library.Joystick
{
    public class JoystickPlayerExample : MonoBehaviour
    {
        public float speed;
        public VariableJoystick variableJoystick;
        public Rigidbody rb;

        public void FixedUpdate()
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}