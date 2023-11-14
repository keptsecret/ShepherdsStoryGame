using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGate3 : MonoBehaviour
{
    public bool stump3HasBeenActivated;
    // Start is called before the first frame update
    void Start()
    {
        stump3HasBeenActivated = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            stump3HasBeenActivated = true;
        }
    }
}
