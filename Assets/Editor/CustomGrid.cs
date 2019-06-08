using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Grid))]
public class CustomGrid : Editor
{
    public override void OnInspectorGUI() {
           base.OnInspectorGUI();
        if (GUILayout.Button("Generate Grid")) {
            ((Grid) target).GenerateGrid();
        }
    }
}
