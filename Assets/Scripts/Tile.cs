﻿using UnityEngine;

public class Tile : MonoBehaviour {
    private SpriteRenderer _spriteRenderer;
    public Color tileEnable = Color.green;
    public Color tileOccupied = Color.red;
    public bool Occupied;
    private Color originalColor;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = _spriteRenderer.color;
    }

    public void ShowGreenFeedback() {
        _spriteRenderer.color = tileEnable;
    }

    public void ResetOriginalColor()
    {
        _spriteRenderer.color = originalColor;
    }
}
