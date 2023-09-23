using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTriggerScript : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sheep")
        {
            other.gameObject.SetActive(false);
        }
        
        if (playerController != null)
        {
            playerController.IncrementScore();
        }
    }
}
