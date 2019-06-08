using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Block : MonoBehaviour {
    public Tile GetClosestTileIn(List<Tile> collisionTiles) {
        return collisionTiles.OrderBy(tile => tile.GetDistance(transform.position)).First();
    }
}