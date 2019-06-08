using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator))]
public class CustomGrid : Editor
{
    public override void OnInspectorGUI() {
           base.OnInspectorGUI();
        if (GUILayout.Button("Generate Grid")) {
            ((GridGenerator) target).GenerateGrid();
        }
    }
}
