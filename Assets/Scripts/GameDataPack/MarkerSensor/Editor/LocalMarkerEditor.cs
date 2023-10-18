using UnityEngine;
using UnityEditor;

namespace Assets.Library.GameDataPack.MarkerSensor.Editor
{
    [CustomEditor(typeof(LocalMarker), true)]
    public class LocalMarkerEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {

            LocalMarker marker = target as LocalMarker;

            Handles.Label(marker.transform.position + marker.LocalMarkerOffset + Vector3.up * 2, "Point");
            marker.LocalMarkerOffset = Handles.PositionHandle(marker.transform.position + marker.LocalMarkerOffset, Quaternion.identity) - marker.transform.position;
        }

        public override void OnInspectorGUI()
        {
            LocalMarker marker = target as LocalMarker;
            EditorUtility.SetDirty(marker.gameObject);
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();
            marker.LocalMarkerOffset = EditorGUILayout.Vector3Field("Point", marker.LocalMarkerOffset, null);
            GUILayout.EndHorizontal();
        }
    }
}