using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private List<Tile> _collisionTiles = new List<Tile>();    

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision");
        var tile = other.GetComponent<Tile>();
        if(tile == null) return;

        if (!tile.Occupied) {
            tile.ShowGreenFeedback();
        }
    }
}
