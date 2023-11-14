using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGate1 : MonoBehaviour
{
    public bool stump1HasBeenActivated;
    // Start is called before the first frame update
    void Start()
    {
        stump1HasBeenActivated = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            stump1HasBeenActivated = true;
        }
    }
}
