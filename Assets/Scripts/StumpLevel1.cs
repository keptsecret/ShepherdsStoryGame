using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpLevel1 : MonoBehaviour
{

    public bool hasBeenActivated;
    // Start is called before the first frame update
    void Start()
    {
        hasBeenActivated = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hasBeenActivated = true;
        }

    }
}
