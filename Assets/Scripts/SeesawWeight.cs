using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawWeight : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb != null)
        {
            if (collision.collider.gameObject.tag == "Player")
            {
                rb.AddForceAtPosition(rb.transform.position - collision.collider.transform.position, rb.transform.position);
            }
        }
    }
}
