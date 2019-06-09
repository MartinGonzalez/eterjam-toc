using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;

    private int totalSnaps;
    private int initialSnaps;
    public GameObject levelDoneMessage;


    public static GameManager Instance {
        get {
            if (instance == null) {
                var go = new GameObject("Game Manager");
                instance = go.AddComponent<GameManager>();
            }

            return instance;
        }
    }

    // Verdadero número que lleva el conteo
    public int Snaps {
        get { return totalSnaps; }
        set {
            totalSnaps = value;

            if (totalSnaps < 0) {
                totalSnaps = 0;
            }

            if (totalSnaps > initialSnaps) {
                totalSnaps = initialSnaps;
            }
        }
    }

    // Para conservar una referencia del número inicial en el nivel, este valor solo se modifica
    // al comienzo
    public int InitialSnaps {
        get { return initialSnaps; }
        set {
            initialSnaps = value;

            if (initialSnaps < 0) {
                initialSnaps = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Awake() {
        // Singleton pattern
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (levelDoneMessage != null)
            levelDoneMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        CheckGameOver();
    }

    public void CheckGameOver() {
        if (totalSnaps <= 0) {
            //Debug.Log("Level Won!");
            levelDoneMessage.SetActive(true);
        }
    }
}