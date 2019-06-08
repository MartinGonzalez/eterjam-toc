using UnityEngine;

public class Tile : MonoBehaviour {
    private SpriteRenderer _spriteRenderer;
    public Color tileEnable = Color.green;
    public Color tileOccupied = Color.red;
    public bool Occupied;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ShowGreenFeedback() {
        _spriteRenderer.color = tileEnable;
    }
}
