using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate3Check : MonoBehaviour
{
    public PuzzleGate3 puzzleGate;
    // Update is called once per frame
    void Update()
    {
        if (puzzleGate.stump3HasBeenActivated)
        {
            Destroy(this.gameObject);
        }
    }
}
