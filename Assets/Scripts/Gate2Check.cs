using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2Check : MonoBehaviour
{
    public PuzzleGate2 puzzleGate;
    // Update is called once per frame
    void Update()
    {
        if (puzzleGate.stump2HasBeenActivated)
        {
            Destroy(this.gameObject);
        }
    }
}
