using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGate : MonoBehaviour
{
    public StumpLevel1 stump1;
    public StumpLevel1 stump2;
    public StumpLevel1 stump3;


    void Update()
    {
        if (stump1.hasBeenActivated && stump2.hasBeenActivated && stump3.hasBeenActivated)
        {
            Destroy(this.gameObject);
        }
    }

}
