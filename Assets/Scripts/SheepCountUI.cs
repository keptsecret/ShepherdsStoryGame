using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SheepCountUI : MonoBehaviour
{
    public TextMeshProUGUI sheepCountText; // Reference to the Text component in the UI

    private void Start()
    {
        sheepCountText.text = GameManager.instance.sheepAliveCount.ToString();
    }

    private void Update()
    {
        // Update the UI Text component with the sheep count
        sheepCountText.text = GameManager.instance.sheepAliveCount.ToString();
    }
}