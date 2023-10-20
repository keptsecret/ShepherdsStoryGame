using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStateManager : MonoBehaviour
{
    public string NextLevel;

    private int score;
    public int SheepCount;

    void Start()
    {
        
    }

    void Update()
    {
        if (score == SheepCount)
        {
            SceneManager.LoadScene(NextLevel);
        }
    }

    public void IncrementScore()
    {
        score++;
    }
}
