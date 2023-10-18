using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Library.Pooling;

namespace Assets.Library.Pooling.Editor
{
    [CustomEditor(typeof(PoolInfoWithPool))]
    public class PoolInfoWithPoolEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            PoolInfoWithPool poolInfo = target as PoolInfoWithPool;

            if (poolInfo.Prefab != null)
                if (poolInfo.Prefab.GetComponent<IPoolObject>() == null)
                {

                    EditorGUILayout.HelpBox("Prefab To be pooled supposed to have an IPoolObject Interface Extender " +
                        "to be able to reset the object to instantiation state", MessageType.Error);
                    GUI.color = Color.red;

                }

            base.OnInspectorGUI();

        }
    }
}