using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToHowTo : MonoBehaviour
{
    public bool GoToHowToMenu;

    public void GoHowTo()
    {
        string levelname = GoToHowToMenu ? "HowToMenu" : SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelname);
        Time.timeScale = 1f;
    }
}