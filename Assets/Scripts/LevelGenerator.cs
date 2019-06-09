using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject GameObject;

    public void CreateLevelData(int totalSnaps) {
        Instantiate(GameObject).GetComponent<LevelData>().totalSnapsInLevel = totalSnaps;
    }
}
