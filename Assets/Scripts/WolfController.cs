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
    }

    void OnAnimatorMove()
    {

        Vector3 newRootPosition = anim.rootPosition;
        newRootPosition = Vector3.LerpUnclamped(this.transform.position, newRootPosition, 1f);

        rb.MovePosition(newRootPosition);
        Debug.Log(newRootPosition.ToString());
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