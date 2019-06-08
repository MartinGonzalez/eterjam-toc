using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour {
    public int itemNumberOfTiles = 1;
    private bool isDragging = false;
    private bool wasSnapped = false;

    private List<Tile> _collisionTiles = new List<Tile>();
    private Collider itemCollider;
    public List<Block> _innerBlocks = new List<Block>();
    public List<Tile> newList = new List<Tile>();

    private void Awake() {
        itemCollider = GetComponent<Collider>();
    }

    private void FixedUpdate() {
        if (!_collisionTiles.Any() || !isDragging) {
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
            if (!tile.Occupied)
                tile.ShowGreenFeedback();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var tile = other.GetComponent<Tile>();
        if (tile == null) return;

        _collisionTiles.Add(tile);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        var tile = collision.GetComponent<Tile>();
        if (tile == null) return;

        tile.ResetOriginalColor();
        _collisionTiles.Remove(tile);
    }


    private bool _snapped;

    private void OnMouseDrag() {
        isDragging = true;
        if (wasSnapped) {
            wasSnapped = false;
            GameManager.Instance.Snaps += 1;
        }


        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);

        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.Rotate(new Vector3(0, 0, 90));
        }

        if (_snapped) {
            foreach (var tile in newList) {
                tile.Occupied = false;
            }

            _snapped = false;
        }
    }

    private void OnMouseUp() {
        isDragging = false;

        if (newList.Count == itemNumberOfTiles && newList.All(tile => tile.Occupied == false)) {
            _snapped = true;
            var totalX = 0f;
            var totalY = 0f;
            foreach (var tile in newList) {
                totalX += tile.transform.position.x;
                totalY += tile.transform.position.y;
            }

            var centerX = totalX / itemNumberOfTiles;
            var centerY = totalY / itemNumberOfTiles;

            transform.position = new Vector3(centerX, centerY, transform.position.z);
            GameManager.Instance.Snaps -= 1;
            wasSnapped = true;

            foreach (var tile in newList) {
                tile.Occupied = true;
                tile.ResetOriginalColor();
            }
        }

        foreach (var tile in newList) {
            tile.ResetOriginalColor();
        }
    }
}