using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameManager gameManager;

    private void Update()
    {
        if (gameManager != null && timerText != null)
        {
            int minutes = Mathf.FloorToInt(gameManager.currentTime / 60); // Get minutes
            int seconds = Mathf.FloorToInt(gameManager.currentTime % 60); // Get seconds
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}