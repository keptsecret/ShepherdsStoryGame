using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Elevator : MonoBehaviour
{
    public BlueSphere sphere;
    private FlowerManager flowerManager;
    public bool activated;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        GameObject otherObject = GameObject.Find("ElevatorCube");
        myAnimator = otherObject.GetComponent<Animator>();
        flowerManager = GameObject.FindObjectOfType<FlowerManager>();
    }

    private void FixedUpdate()
    {
        if (flowerManager.inFlowerCircle1 && flowerManager.inFlowerCircle2 && flowerManager.inFlowerCircle3)
        {
            activated = true;
            myAnimator.SetBool("activated", true);
        }
        else
        {
            myAnimator.SetBool("activated", false);
        }
    }
}