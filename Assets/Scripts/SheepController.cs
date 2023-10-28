using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private Vector3 movementDir;
    private float speed;

    private Rigidbody rb;
    private Animator anim;

    //private bool isAlive = true;

    // for calculating velocity
    public float smoothingTimeFactor = 0.5f;
    private Vector3 smoothingParamVel;
    private Vector3 prevPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        prevPos = this.transform.position;
        isAlive = true;

    }

    private void Update()
    {
        if (!Mathf.Approximately(Time.deltaTime, 0f))
        {
            rawVelocity = (this.transform.position - prevPos) / Time.deltaTime;
            velocity = Vector3.SmoothDamp(velocity, rawVelocity, ref smoothingParamVel, smoothingTimeFactor);
        }
        else
        {
            rawVelocity = new Vector3(0, 0, 0);
            velocity = new Vector3(0, 0, 0);
        }
        prevPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
             float eulerY = rb.transform.eulerAngles.y;
            if (movementDir.magnitude > 0.01f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(movementDir.normalized, rb.transform.up);
                float diffRotation = lookRotation.eulerAngles.y - rb.transform.eulerAngles.y;

                if (diffRotation > 0f || diffRotation < 0f)
                {
                    eulerY = lookRotation.eulerAngles.y;
                }
            }
            Vector3 eulerRotation = new Vector3(0, eulerY, 0);
            rb.MoveRotation(Quaternion.SlerpUnclamped(rb.transform.rotation, Quaternion.Euler(eulerRotation), Time.fixedDeltaTime * 2f));

            float forward = Vector3.Dot(movementDir, rb.transform.forward);
            anim.SetFloat("vely", Mathf.Clamp01(forward * speed * 2f));
        }
    }

    void OnAnimatorMove()
    {
        if (isAlive)
        {
            Vector3 newRootPosition = anim.rootPosition;
            newRootPosition = Vector3.LerpUnclamped(this.transform.position, newRootPosition, 1f);

            rb.MovePosition(newRootPosition);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 dir = transform.position - other.transform.position;
            movementDir = new Vector3(dir.x, 0, dir.z);
            movementDir = movementDir.normalized;
            speed = Mathf.Max((5f - dir.magnitude) / 5f, 0.1f);
        }

        if (other.gameObject.tag == "Sheep")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movementDir = new Vector3();
            speed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAlive && collision.gameObject.CompareTag("Wolf"))
        {
            anim.SetTrigger("DieTrigger");
            isAlive = false;
        }
    }

    public Vector3 rawVelocity
    {
        get;
        private set;
    }
    public Vector3 velocity
    {
        get;
        private set;
    }
    public bool isAlive
    {
        get;
        private set;
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
