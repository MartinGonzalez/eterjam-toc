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
        GameManager.instance.InitialSnaps = totalSnapsInLevel;
        GameManager.instance.Snaps = totalSnapsInLevel;
        GameManager.instance.levelDoneMessage = levelClearMessage;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
