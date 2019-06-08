using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour {
    public int itemNumberOfTiles = 1;    

    private List<Tile> _collisionTiles = new List<Tile>();
    private Collider2D itemCollider;
    public List<Block> _innerBlocks = new List<Block>();

    private void Awake() {
        itemCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        if (!_collisionTiles.Any()) {
            return;
        }
        
        var newList = new List<Tile>();
        
        foreach (var innerBlock in _innerBlocks) {
            newList.Add(innerBlock.GetClosestTileIn(_collisionTiles));
        }

        foreach (var collisionTile in _collisionTiles) {
            if(!newList.Contains(collisionTile))
                collisionTile.ResetOriginalColor();
        }

        foreach (var tile in newList) {
            tile.ShowGreenFeedback();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var tile = other.GetComponent<Tile>();
        if (tile == null) return;

        if (!tile.Occupied) {
            _collisionTiles.Add(tile);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        var tile = collision.GetComponent<Tile>();
        if (tile == null) return;

        tile.ResetOriginalColor();
        _collisionTiles.Remove(tile);
    }
}