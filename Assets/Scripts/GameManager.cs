using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private int totalSnaps;
    [HideInInspector] public GameObject levelDoneMessage;

    public int Snaps
    {
        get
        {
            return totalSnaps;
        }
        set
        {
            totalSnaps = value;

            if (totalSnaps < 0)
            {
                totalSnaps = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        // Singleton pattern
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if(levelDoneMessage != null)
            levelDoneMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
    }

    public void CheckGameOver()
    {
        if (totalSnaps <= 0)
        {
            //Debug.Log("Level Won!");
            levelDoneMessage.SetActive(true);
        }
    }
}
