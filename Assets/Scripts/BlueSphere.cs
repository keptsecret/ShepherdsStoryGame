using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSphere : MonoBehaviour
{
    public Transform sphere;  
    public float push = 10f; 
    public float activationDistance = 5f; 
    public bool playerTouch;
    private FlowerManager flowerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerTouch = false;
        flowerManager = GameObject.FindObjectOfType<FlowerManager>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Flower1")
        {
            flowerManager.inFlowerCircle1 = true;
        }

        if (other.gameObject.tag == "Flower2")
        {
            flowerManager.inFlowerCircle2 = true;
        }

        if (other.gameObject.tag == "Flower3")
        {
            flowerManager.inFlowerCircle3 = true;
        }

        if (other.gameObject.tag == "Player")
        {
            playerTouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Flower1")
        {
            flowerManager.inFlowerCircle1 = false;
        }

        if (other.gameObject.tag != "Flower2")
        {
            flowerManager.inFlowerCircle1 = false;
        }

        if (other.gameObject.tag != "Flower3")
        {
            flowerManager.inFlowerCircle1 = false;
        }
    }



    private void Update()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= activationDistance)
        {
            PushSphere();
        }
    }

    void PushSphere()
    {
        Vector3 pushDirection = (sphere.position - transform.position).normalized;
        sphere.GetComponent<Rigidbody>().AddForce(pushDirection * push, ForceMode.Impulse);
    }
}
