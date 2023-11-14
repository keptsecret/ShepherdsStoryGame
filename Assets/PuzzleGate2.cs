using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGate2 : MonoBehaviour
{
    public bool stump2HasBeenActivated;
    // Start is called before the first frame update
    void Start()
    {
        stump2HasBeenActivated = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            stump2HasBeenActivated = true;
        }
    }
}
