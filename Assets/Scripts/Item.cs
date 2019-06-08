using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemNumberOfTiles = 6;
    public float[] touchingTilesDistance = new float[6];
    public Tile[] closestTiles = new Tile[6];
     
    private List<Tile> _collisionTiles = new List<Tile>();
    private Collider2D itemCollider;

    private void Awake()
    {
        itemCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if(!_collisionTiles.Any())
        {
            return;
        }

        // Distancia entre el objeto a poner y cada cuadrado que toca
        for (int i = 0; i < _collisionTiles.Count; i++)
        {
            Collider2D _tileCollider = _collisionTiles[i].GetComponent<Collider2D>();
            ColliderDistance2D _distance = itemCollider.Distance(_tileCollider);

            // Nos quedamos solo con los más cercanos
            for (int k = 0; k < touchingTilesDistance.Length; k++)
            {
                if (_distance.distance < touchingTilesDistance[i])
                {
                    closestTiles[k] = _collisionTiles[i];
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision");
        var tile = other.GetComponent<Tile>();
        if(tile == null) return;

        if (!tile.Occupied) {
            tile.ShowGreenFeedback();
            _collisionTiles.Add(tile);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var tile = collision.GetComponent<Tile>();
        if (tile == null) return;
        
            tile.ResetOriginalColor();
            _collisionTiles.Remove(tile);
    }
}
