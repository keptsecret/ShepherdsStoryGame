using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate1Check : MonoBehaviour
{
    public PuzzleGate1 puzzleGate;
    // Update is called once per frame
    void Update()
    {
        if (puzzleGate.stump1HasBeenActivated)
        {
            Destroy(this.gameObject);
        }
    }
}
