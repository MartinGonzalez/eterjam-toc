using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Block : MonoBehaviour {
    private void Awake()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0,0,0,0);
    }

    public Tile GetClosestTileIn(List<Tile> collisionTiles) {
        return collisionTiles.OrderBy(tile => tile.GetDistance(transform.position)).First();
    }
}