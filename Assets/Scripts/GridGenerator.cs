using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {
    public float spaceX = 1.2f;
    public float spaceY = 1.2f;
    public int tilesX = 10;
    public int tilesY = 10;
    public GameObject tilePrefab;
    [SerializeField] private List<Tile> tiles = new List<Tile>();
    private GameObject innerParent;

    public void GenerateGrid() {
        DeleteChildren();
        tiles = new List<Tile>();
        
        var posX = 0f;
        var posY = 0f;
        for (var i = 0; i < tilesY; i++) {
            for (var j = 0; j < tilesX; j++) {
                var tile = Instantiate(tilePrefab, transform);
                tile.transform.localPosition = new Vector3(posX, posY);
                tile.name = j + "_" + i;
                var t = tile.AddComponent<Tile>();
                var collider = tile.AddComponent<BoxCollider2D>();
                collider.isTrigger = true;
                tiles.Add(t);
                posX += spaceX;
            }

            posX = 0;
            posY -= spaceY;
        }

        innerParent = new GameObject("Parent");        
        innerParent.transform.SetParent(transform);        
        
        var totalX = 0f;
        var totalY = 0f;
        foreach (var tile in tiles) {
            totalX += tile.transform.localPosition.x;
            totalY += tile.transform.localPosition.y;
        }

        var centerX = totalX / (tilesX * tilesY);
        var centerY = totalY / (tilesY * tilesX);

        innerParent.transform.localPosition = new Vector3(centerX, centerY);
        
        foreach (var tile in tiles) {
            tile.transform.SetParent(innerParent.transform);
        }
        
        innerParent.transform.localPosition = Vector3.zero;
    }

    private void DeleteChildren() {
        DestroyImmediate(innerParent);
    }

    public void ShowTilesIn(List<ItemEditor> items) {
        foreach (var tile in tiles) {
            tile.Hide();
        }
        
        foreach (var item in items) {
            foreach (var coordinate in item.Coordinates) {
                var index = coordinate.Y * tilesX + coordinate.X;
                tiles[index].Show();
            }
        }
    }
}