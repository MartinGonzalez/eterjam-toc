using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public int totalSnapsInLevel;
    public GameObject levelClearMessage;

    private void Start()
    {
        GameManager.Instance.InitialSnaps = totalSnapsInLevel;
        GameManager.Instance.Snaps = totalSnapsInLevel;
        GameManager.Instance.levelDoneMessage = levelClearMessage;
    }
}
