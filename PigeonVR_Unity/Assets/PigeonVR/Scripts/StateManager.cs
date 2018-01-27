using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public static StateManager instance = null;
    [SerializeField]
    private int lives;
    public int Lives
    {
        get
        {
            return Lives;
        }
    }
    [SerializeField]
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
    }

    public delegate void StateChangeAction(int score, int lives);
    public event StateChangeAction onStateUpdate;

    void Awake()
    {
        // setup of Singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public static StateManager Instance
    {
        get
        {
            return instance ?? (instance = new GameObject("GameManager").AddComponent<StateManager>());
        }
    }

    public void updateScore(int i)
    {
        score += i;
    }

    public void updateAfterThrow(bool success)
    {
        if (success)
        {
            updateScore(1);
        }
        else
        {
            if (lives == 1)
            {
                gameOver();
            }
            else
            {
                lives -= 1;
            }
        }
        onStateUpdate(score, lives);
    }


    public void gameOver()
    {

    }

}