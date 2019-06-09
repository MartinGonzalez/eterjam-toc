using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.iOS;
using UnityEngine;

public class DesktopGeneratorEditor : EditorWindow {
    bool[,] matrix = new bool[11, 5];
    private bool _addingItem;


    [MenuItem("Level Generator/Generate")]
    public static void LevelGenerator() {
        var window = GetWindow<DesktopGeneratorEditor>();
        window.minSize = new Vector2(600, 400);
    }

    private void OnGUI() {
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        GUI.enabled = !_addingItem;
        if (GUILayout.Button("Add Item")) {
            _addingItem = true;
        }

        GUI.enabled = true;

        GUI.enabled = _addingItem;
        if (GUILayout.Button("Save Item")) { 
            _addingItem = false;
            _items.Add(new ItemEditor(_currentCoordintes));
            _currentCoordintes = new List<Coordinates>();
        }


        GUI.enabled = _items.Count > 0;
        if (GUILayout.Button("Generate Grid")) {
            var grid = FindObjectOfType<GridGenerator>();
            grid.ShowTilesIn(_items);
            foreach (var item in _items) {
                item.ResetCoordinates();
            }
        }
        
        if (GUILayout.Button("Clear Grid")) {
            _items = new List<ItemEditor>();
            matrix = new bool[11, 5];
            _currentCoordintes = new List<Coordinates>();            
        }
        
        GUI.enabled = true;

        if (GUILayout.Button("Debug List")) {
            Debug.Log("------ Current Coordinates");

            foreach (var coordinte in _currentCoordintes) {
                Debug.Log(coordinte.X + "_" + coordinte.Y);
            }

            Debug.Log("------ Itmes: " + _items.Count);
            foreach (var item in _items) {
                foreach (var coordinate in item.Coordinates) {
                    Debug.Log("Item with: " + coordinate.X + "_" + coordinate.Y);
                }
            }
        }

        GUILayout.EndVertical();

        GUI.enabled = _addingItem;
        DrawGrid();
        GUI.enabled = true;

        GUILayout.EndHorizontal();
    }

    private List<ItemEditor> _items = new List<ItemEditor>();
    private List<Coordinates> _currentCoordintes = new List<Coordinates>();

    private void DrawGrid() {
        GUILayout.BeginVertical();
        for (var i = 0; i < matrix.GetLength(1); i++) {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            for (var j = 0; j < matrix.GetLength(0); j++) {
                GUI.enabled = _addingItem && IsNotOccupied(j, i);
                EditorGUI.BeginChangeCheck();
                matrix[j, i] = GUILayout.Toggle(matrix[j, i], GUIContent.none);
                if (EditorGUI.EndChangeCheck()) {
                    if (matrix[j, i])
                        _currentCoordintes.Add(new Coordinates(j, i));
                    else
                        _currentCoordintes.Remove(new Coordinates(j, i));
                }

                GUI.enabled = true;
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        GUILayout.EndVertical();
    }

    private bool IsNotOccupied(int x, int y) {
        foreach (var item in _items) {
            if (item.HasCoordinates(x, y))
                return false;
        }

        return true;
    }
}