using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {
    public float spaceX = 1.2f;
    public float spaceY = 1.2f;
    public int tilesX = 10;
    public int tilesY = 10;
    public GameObject tilePrefab;
    private List<Transform> bla = new List<Transform>();
    private GameObject innerParent;

    public void GenerateGrid() {
        DeleteChildren();
        bla = new List<Transform>();

        var posX = 0f;
        var posY = 0f;
        for (var i = 0; i < tilesY; i++) {
            for (var j = 0; j < tilesX; j++) {
                var tile = Instantiate(tilePrefab, transform);
                tile.transform.localPosition = new Vector3(posX, posY);
                tile.name = j + "_" + i;
                tile.AddComponent<Tile>();
                var collider = tile.AddComponent<BoxCollider2D>();
                collider.isTrigger = true;
                bla.Add(tile.transform);
                posX += spaceX;
            }

            posX = 0;
            posY -= spaceY;
        }

        innerParent = new GameObject("Parent");
        innerParent.transform.SetParent(transform);

        var totalX = 0f;
        var totalY = 0f;
        foreach (var tile in bla) {
            totalX += tile.transform.position.x;
            totalY += tile.transform.position.y;
        }

        var centerX = totalX / tilesX * tilesY;
        var centerY = totalY / tilesX * tilesY;

        innerParent.transform.localPosition = new Vector3(centerX, centerY, innerParent.transform.localPosition.z);
        
        foreach (var tile in bla) {
            tile.transform.SetParent(innerParent.transform);
        }
        
        innerParent.transform.localPosition = Vector3.zero;
    }

    private void DeleteChildren() {
        DestroyImmediate(innerParent);
    }
}