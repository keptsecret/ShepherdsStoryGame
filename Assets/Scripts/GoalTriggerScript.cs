using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTriggerScript : MonoBehaviour
{
    public GameObject manager;
    private LevelStateManager levelStateManager;

    private void Start()
    {
        levelStateManager = manager.GetComponent<LevelStateManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sheep" && !other.isTrigger)
        {
            other.gameObject.SetActive(false);
            if (levelStateManager != null)
            {
                levelStateManager.IncrementScore();
            }
        }
    }
}
