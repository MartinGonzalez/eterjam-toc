using UnityEngine;

public class GridGenerator : MonoBehaviour {
    public float spaceX = 1.2f;
    public float spaceY = 1.2f;
    public int tilesX = 10;
    public int tilesY = 10;
    public GameObject tilePrefab;
    
    public void GenerateGrid() {
        var posX = 0f;
        var posY = 0f;
        for (var i = 0; i < tilesY; i++) {
            for (var j = 0; j < tilesX; j++) {
                var tile = Instantiate(tilePrefab, transform);
                tile.transform.localPosition = new Vector3(posX, posY);
                posX += spaceX;
            }

            posX = 0;
            posY -= spaceY;
        }            
    }
}