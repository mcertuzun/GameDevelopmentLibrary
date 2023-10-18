﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Assets.Library.Joystick
{
    [CustomEditor(typeof(FloatingJoystick), true)]
    public class FloatingJoystickEditor : JoystickEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (background != null)
            {
                RectTransform backgroundRect = (RectTransform)background.objectReferenceValue;
                backgroundRect.anchorMax = Vector2.zero;
                backgroundRect.anchorMin = Vector2.zero;
                backgroundRect.pivot = center;
            }
        }
    }
}