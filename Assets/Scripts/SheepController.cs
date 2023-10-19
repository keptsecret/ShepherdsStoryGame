using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private Vector3 movement;
    private float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 dir = other.transform.position - transform.position;
            movement = dir.normalized;
            speed = 1 - dir.magnitude;
        }

        if (other.gameObject.tag == "Sheep")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movement = new Vector3();
            speed = 0;
        }
    }
}


//using UnityEngine;

//public class SheepController : MonoBehaviour
//{
//    private Vector3 movement;
//    private float speed;

//    private Rigidbody rb;

//    private bool inGroup = false;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        if (inGroup)
//        {
//            return;
//        }
//    }

//    private void FixedUpdate()
//    {
//        if (inGroup)
//        {
//            return;
//        }

//        rb.AddForce(movement * speed * 5);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            Vector3 dir = other.transform.position - transform.position;
//            movement = dir.normalized;
//            speed = 1 - dir.magnitude;
//        }

//        if (other.gameObject.tag == "Sheep")
//        {
//            if (!inGroup)
//            {
//                inGroup = true;
//                SheepGroupManager.Instance.AddSheepToGroup(this);
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            movement = new Vector3();
//            speed = 0;
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SheepController : MonoBehaviour
//{
//    private Vector3 movement;
//    private float speed;

//    private Rigidbody rb;

//    private bool isFlocking = false; 

//    [Header("Flocking Settings")]
//    public float flockingRadius = 5f;
//    public float separationDistance = 2f;
//    public float flockSpeed = 1f;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    void FixedUpdate()
//    {
//        if (isFlocking)
//        {
//            Flock();
//        }
//        else
//        {
//            rb.AddForce(movement * speed * 5);
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("Player"))
//        {
//            Vector3 dir = other.transform.position - transform.position;
//            movement = dir.normalized;
//            speed = 1 - dir.magnitude;
//        }

//        if (other.gameObject.CompareTag("Sheep"))
//        {
//            isFlocking = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.CompareTag("Player"))
//        {
//            movement = Vector3.zero;
//            speed = 0;
//        }
//    }

//    // Flocking behavior
//    private void Flock()
//    {
//        Collider[] colliders = Physics.OverlapSphere(transform.position, flockingRadius);

//        Vector3 moveDirection = Vector3.zero;
//        Vector3 separationDirection = Vector3.zero;
//        int flockmatesCount = 0;

//        foreach (Collider col in colliders)
//        {
//            if (col.gameObject != gameObject && col.CompareTag("Sheep"))
//            {
//                // Cohesion
//                moveDirection += col.transform.position;

//                // Separation
//                Vector3 toNeighbor = transform.position - col.transform.position;
//                if (toNeighbor.magnitude < separationDistance)
//                {
//                    separationDirection += toNeighbor.normalized / toNeighbor.magnitude;
//                }

//                flockmatesCount++;
//            }
//        }

//        if (flockmatesCount > 0)
//        {
//            // Average out the move direction
//            moveDirection /= flockmatesCount;

//            // Apply cohesion
//            Vector3 cohesionForce = (moveDirection - transform.position).normalized * flockSpeed;
//            rb.velocity += cohesionForce * Time.fixedDeltaTime;

//            // Apply separation
//            Vector3 separationForce = separationDirection.normalized * flockSpeed;
//            rb.velocity += separationForce * Time.fixedDeltaTime;
//        }

//        // Align with the average velocity of flockmates
//        Vector3 averageVelocity = rb.velocity / rb.velocity.magnitude;
//        rb.velocity = averageVelocity * flockSpeed;
//    }
//}
