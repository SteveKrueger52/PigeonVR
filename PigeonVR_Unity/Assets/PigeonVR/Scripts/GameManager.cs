using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    private static int score;
    private int lives;

    public static int Score
    {
        get
        {
            return score;
        }
    }

    void Awake()
    {
        // setup of Singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;

        score = 0;
        lives = 3;

        DontDestroyOnLoad(this.gameObject);
    }

    public static GameManager Instance
    {
        get
        {
            return instance ?? (instance = new GameObject("GameManager").AddComponent<GameManager>());
        }
    }

    public static void updateScore(int i)
    {
        score += i;
    }
}
