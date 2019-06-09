using UnityEngine;

public class Tile : MonoBehaviour {
    private SpriteRenderer _spriteRenderer;
    public Color tileEnable = Color.green;
    public Color tileOccupied = Color.red;
    public bool Occupied;
    private Color originalColor;

    public float Distance;
    
    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_spriteRenderer.color = new Color(0,0,0,0);
        originalColor = _spriteRenderer.color;
    }

    public void ShowGreenFeedback() {
        _spriteRenderer.color = tileEnable;
    }

    public void ResetOriginalColor() {
        _spriteRenderer.color = originalColor;
    }

    public float GetDistance(Vector3 transformPosition) {
        Distance = Vector3.Distance(transform.position, transformPosition);
        return Distance;
    }

    public void ShowRedFeedback()
    {
        _spriteRenderer.color = tileOccupied;
    }

    public void Show() {
        gameObject.SetActive(true);
    }
    
    public void Hide() {
        gameObject.SetActive(false);
    }
}