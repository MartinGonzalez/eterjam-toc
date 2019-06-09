using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelData : MonoBehaviour
{
    public int totalSnapsInLevel;
    public GameObject levelClearMessage;
    public Button button;

    private void Awake() {
        levelClearMessage.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.InitialSnaps = totalSnapsInLevel;
        GameManager.Instance.Snaps = totalSnapsInLevel;
        GameManager.Instance.levelDoneMessage = levelClearMessage;
        button.onClick.AddListener(NextScene);
    }

    public void NextScene() {
        var index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }
}
