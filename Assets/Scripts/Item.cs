using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour {
    public int itemNumberOfTiles = 1;
    private bool isDragging = false;

    private List<Tile> _collisionTiles = new List<Tile>();
    private Collider2D itemCollider;
    public List<Block> _innerBlocks = new List<Block>();
    public List<Tile> newList = new List<Tile>();

    private void Awake() {
        itemCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        if (!_collisionTiles.Any()) {
            return;
        }

        newList = new List<Tile>();

        foreach (var innerBlock in _innerBlocks) {
            newList.Add(innerBlock.GetClosestTileIn(_collisionTiles));
        }

        foreach (var collisionTile in _collisionTiles) {
            if (!newList.Contains(collisionTile))
                collisionTile.ResetOriginalColor();
        }

        newList = newList.Distinct().ToList();

        foreach (var tile in newList) {
            if(isDragging)
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


    private void OnMouseDrag() {
        isDragging = true;

        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);

        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.Rotate(new Vector3(0, 0, 90));
        }

        foreach (var tile in newList)
        {
            tile.Occupied = false;
        }
    }

    private void OnMouseUp() {
        isDragging = false;

        if (newList.Count == itemNumberOfTiles) {
            var totalX = 0f;
            var totalY = 0f;
            foreach (var tile in newList) {
                totalX += tile.transform.position.x;
                totalY += tile.transform.position.y;
            }

            var centerX = totalX / itemNumberOfTiles;
            var centerY = totalY / itemNumberOfTiles;

            transform.position = new Vector3(centerX, centerY, transform.position.z);

            foreach (var tile in newList)
            {
                tile.Occupied = true;
                tile.ResetOriginalColor();
            }
        }
    }
}