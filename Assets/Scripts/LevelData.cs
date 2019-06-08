using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public int totalSnapsInLevel;
    public GameObject levelClearMessage;

    private void Start()
    {
        GameManager.instance.InitialSnaps = totalSnapsInLevel;
        GameManager.instance.Snaps = totalSnapsInLevel;
        GameManager.instance.levelDoneMessage = levelClearMessage;
    }
}
