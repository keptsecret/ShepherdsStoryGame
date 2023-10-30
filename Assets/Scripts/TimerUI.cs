using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private void Update()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(GameManager.instance.currentTime / 60); // Get minutes
            int seconds = Mathf.FloorToInt(GameManager.instance.currentTime % 60); // Get seconds
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}