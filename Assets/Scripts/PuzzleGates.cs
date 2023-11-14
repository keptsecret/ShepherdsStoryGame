using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGates : MonoBehaviour
{
    public GameObject stump1;
    public GameObject stump2;
    public GameObject stump3;
    public bool stump1HasBeenActivated;
    public bool stump2HasBeenActivated;
    public bool stump3HasBeenActivated;
    // Start is called before the first frame update
    void Start()
    {
        stump1HasBeenActivated = false;
        stump2HasBeenActivated = false;
        stump3HasBeenActivated = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key" && stump1)
        {
            stump1HasBeenActivated = true;
        }
        if (other.gameObject.tag == "Key" && stump2)
        {
            stump2HasBeenActivated = true;
        }
        if (other.gameObject.tag == "Key" && stump3)
        {
            stump3HasBeenActivated = true;
        }
    }
}
