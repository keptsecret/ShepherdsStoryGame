using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultRight : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Rigidbody currentSheepRigidbody;
    private bool allowJump = false;
    private bool allowSheepJump = false;
    private float waitTime;

    void Start()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        setWait();
    }

    void setWait()
    {
        waitTime = Time.time + 5.0f;
    }

    void FixedUpdate()
    {
        if (Time.time >= waitTime)
        {
            if (allowJump)
            {
                Jump();
                allowJump = false;
                setWait();
            }

            if (allowSheepJump && currentSheepRigidbody != null)
            {
                sheepJump(currentSheepRigidbody);
                allowSheepJump = false;
                setWait();
            }
        }
    }

    void Jump()
    {
        // Apply jump force to the player
        //playerRigidbody.AddForce(Vector3.right * 4000.0f, ForceMode.Impulse);
        //playerRigidbody.AddForce(Vector3.up * 300, ForceMode.Impulse);
    }

    void sheepJump(Rigidbody sheepRigidbody)
    {
        // Apply jump force to the specific sheep
        sheepRigidbody.AddForce(Vector3.right * 400.0f, ForceMode.Impulse);
        sheepRigidbody.AddForce(Vector3.up * 200, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            allowJump = true;
        }

        if (collision.gameObject.CompareTag("Sheep"))
        {
            allowSheepJump = true;
            currentSheepRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            // Reset the current sheep's Rigidbody when it exits the collision
            currentSheepRigidbody = null;
        }
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Catapult : MonoBehaviour
//{
//    private Rigidbody playerRigidbody;
//    private List<Rigidbody> sheepRigidbodies = new List<Rigidbody>();
//    private bool allowJump = false;
//    private bool allowSheepJump = false;
//    private float waitTime;

//    void Start()
//    {
//        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
//        GameObject[] sheepObjects = GameObject.FindGameObjectsWithTag("Sheep");
//        foreach (var sheepObject in sheepObjects)
//        {
//            sheepRigidbodies.Add(sheepObject.GetComponent<Rigidbody>());
//        }

//        setWait();
//    }

//    void setWait()
//    {
//        waitTime = Time.time + 5.0f;
//    }

//    void FixedUpdate()
//    {
//        if (Time.time >= waitTime)
//        {
//            if (allowJump)
//            {
//                Jump();
//                allowJump = false;
//                setWait();
//            }

//            if (allowSheepJump)
//            {
//                foreach (var sheepRigidbody in sheepRigidbodies)
//                {
//                    sheepJump(sheepRigidbody);
//                }
//                allowSheepJump = false;
//                setWait();
//            }
//        }
//    }

//    void Jump()
//    {
//        // 100000 forward and 1000 up at 20 mass got them to the far island
//        //Vector3 jumpForce = new Vector3(0, 500.0f, 10000.0f);
//        playerRigidbody.AddForce(Vector3.forward * 100000.0f, ForceMode.Impulse);
//        playerRigidbody.AddForce(Vector3.up * 1000, ForceMode.Impulse);
//    }

//    void sheepJump(Rigidbody sheepRigidbody)
//    {
//        // 100000 forward and 1000 up at 20 mass got them to the far island
//        //Vector3 jumpForce = new Vector3(0, 500.0f, 10000.0f);
//        sheepRigidbody.AddForce(Vector3.forward * 100000.0f, ForceMode.Impulse);
//        sheepRigidbody.AddForce(Vector3.up * 1000, ForceMode.Impulse);
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            allowJump = true;
//        }

//        if (collision.gameObject.CompareTag("Sheep"))
//        {
//            allowSheepJump = true;
//        }
//    }
//}
