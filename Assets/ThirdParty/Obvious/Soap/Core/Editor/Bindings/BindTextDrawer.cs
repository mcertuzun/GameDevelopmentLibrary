﻿using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Obvious.Soap
{
    [CustomEditor(typeof(BindText))]
    [CanEditMultipleObjects]
    public class BindTextDrawer : Editor
    {
        BindText _targetScript;
        SerializedProperty _boolVariableProperty;
        SerializedProperty _intVariableProperty;
        SerializedProperty _floatVariableProperty;
        SerializedProperty _stringVariableProperty;

        void OnEnable()
        {
            _targetScript = (BindText)target;
            _boolVariableProperty = serializedObject.FindProperty("_boolVariable");
            _intVariableProperty = serializedObject.FindProperty("_intVariable");
            _floatVariableProperty = serializedObject.FindProperty("_floatVariable");
            _stringVariableProperty = serializedObject.FindProperty("_stringVariable");
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            Undo.RecordObject(_targetScript, "Modified Custom Inspector");
            _targetScript.Type = (CustomVariableType)EditorGUILayout.EnumPopup("Variable Type", _targetScript.Type);
            _targetScript.Prefix = EditorGUILayout.TextField(new GUIContent("Prefix",
                "Adds a text in front of the value"), _targetScript.Prefix);
            _targetScript.Suffix = EditorGUILayout.TextField(new GUIContent("Suffix",
                "Adds a text after the value"), _targetScript.Suffix);

            switch (_targetScript.Type)
            {
                case CustomVariableType.NONE:
                    break;
                case CustomVariableType.BOOL:
                    EditorGUILayout.PropertyField(_boolVariableProperty, new GUIContent("Bool"));
                    break;
                case CustomVariableType.INT:
                    EditorGUILayout.PropertyField(_intVariableProperty, new GUIContent("Int"));
                    _targetScript.Increment = EditorGUILayout.IntField(new GUIContent("Increment",
                            "Useful to add an offset, for example for Level counts. If your level index is  0, add 1, so it displays Level : 1"),
                        _targetScript.Increment);
                    _targetScript.IsClamped = EditorGUILayout.Toggle(new GUIContent("Is Clamped",
                        "Clamps the value shown to a minimum and a maximum."), _targetScript.IsClamped);
                    if (_targetScript.IsClamped)
                    {
                        var minMaxInt = EditorGUILayout.Vector2IntField("Min Max", _targetScript.MinMaxInt);
                        _targetScript.MinMaxInt = minMaxInt;
                    }

                    break;
                case CustomVariableType.FLOAT:
                    EditorGUILayout.PropertyField(_floatVariableProperty, new GUIContent("Float"));
                    var decimalAmount = EditorGUILayout.IntField(new GUIContent("Decimal",
                        "Round the float to a decimal"), _targetScript.DecimalAmount);
                    _targetScript.DecimalAmount = Mathf.Clamp(decimalAmount, 0, 5);
                    _targetScript.IsClamped = EditorGUILayout.Toggle(new GUIContent("Is Clamped",
                        "Clamps the value shown to a minimum and a maximum."), _targetScript.IsClamped);
                    if (_targetScript.IsClamped)
                    {
                        var minMaxFloat = EditorGUILayout.Vector2Field("Min Max", _targetScript.MinMaxFloat);
                        _targetScript.MinMaxFloat = minMaxFloat;
                    }

                    break;
                case CustomVariableType.STRING:
                    EditorGUILayout.PropertyField(_stringVariableProperty, new GUIContent("String"));
                    break;
            }

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                if (!Application.isPlaying)
                    EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            }
        }
    }
}