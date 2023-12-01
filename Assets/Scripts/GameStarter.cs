using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public bool GoToFirstLevel;

    public void StartGame()
    {
        string levelname = GoToFirstLevel ? "Steven Level" : SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelname);
        GameManager.instance.sceneReady = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}