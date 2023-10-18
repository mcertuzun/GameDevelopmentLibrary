using UnityEngine;
using UnityEditor;
using Assets.Library.LevelDesign.LevelScriptableCreator;

namespace Assets.Library.LevelDesign.LevelScriptableCreator.Editor
{
    [CustomEditor(typeof(BlockSaver))]
    public class BlockSaverEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Save Asset"))
            {
                (target as BlockSaver).saveBlock();
            }

            if (GUILayout.Button("Save Prefab"))
            {
                (target as BlockSaver).saveAsPrefab();
            }

            base.OnInspectorGUI();
        }
    }
}