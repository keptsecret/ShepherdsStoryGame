using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject currentSheep;
    private List<GameObject> availableSheep;
    private Animator anim;
    private Rigidbody rb;

    private float delayTimer = 0.0f;
    public float delayNext = 20.0f;

    void Start()
    {
        delayTimer = delayNext;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        availableSheep = new List<GameObject>(GameObject.FindGameObjectsWithTag("Sheep"));

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;


        // Start chasing the first available sheep
        SetNewTarget();
    }

    void Update()
    {
        anim.SetFloat("vely", navMeshAgent.velocity.magnitude / navMeshAgent.speed);

        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
        }

        if (currentSheep != null)
        {
            float distance = (currentSheep.transform.position - navMeshAgent.transform.position).magnitude;
            float lookAheadT = distance / navMeshAgent.speed;
            Vector3 currentSheepVel = currentSheep.GetComponent<SheepController>().velocity;
            Vector3 futureTarget = currentSheep.transform.position + lookAheadT * currentSheepVel;
            navMeshAgent.SetDestination(futureTarget);
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 1.5f)
            {
                // The wolf has reached its current target sheep
                SetNewTarget();
                delayTimer = delayNext;
                //availableSheep.Remove(currentSheep)
            }
        }
       
    }

    void SetNewTarget()
    {
        if (availableSheep.Count > 0)
        {
            // Find the closest available sheep
            float closestDistance = float.MaxValue;

            foreach (var sheep in availableSheep)
            {
                float distance = Vector3.Distance(transform.position, sheep.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    currentSheep = sheep;
                }
                currentSheep = sheep;
            }


            // Set the new target
            navMeshAgent.SetDestination(currentSheep.transform.position);

            // Remove the targeted sheep from the list of available sheep
            if (currentSheep.GetComponent<SheepController>().isAlive == false)
            {
                availableSheep.Remove(currentSheep);
                GameManager.instance.sheepAliveCount--;
            }

            if (delayTimer <= 0)
            {
                delayTimer = delayNext;
            }
        }
        else
        {
            anim.SetFloat("vely", 0);
        }
    }
}
