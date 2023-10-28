using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    private Vector3 movementDir;
    private float speed;

    private Rigidbody rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        // freeze rotation along x and z axis
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    private void FixedUpdate()
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

        rb.MovePosition(transform.position + movementDir * speed * Time.fixedDeltaTime);

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 dir = transform.position - other.transform.position;
            movementDir = new Vector3(dir.x, 0, dir.z);
            movementDir = movementDir.normalized;
            speed = Mathf.Max((20f - dir.magnitude) / 5f, 0.1f);
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
}