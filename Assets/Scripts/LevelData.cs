using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    public int totalSnapsInLevel;
    public GameObject levelClearMessage;
    public string sceneToLoad;

    private void Start()
    {
        GameManager.Instance.InitialSnaps = totalSnapsInLevel;
        GameManager.Instance.Snaps = totalSnapsInLevel;
        GameManager.Instance.levelDoneMessage = levelClearMessage;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
