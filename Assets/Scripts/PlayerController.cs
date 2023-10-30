using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private Vector2 movement;
    private Vector3 startingPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        startingPosition = new Vector3(-21.62f, 0.1f, -31.02f);
    }

    private void Update()
    {
        anim.SetFloat("velx", movement.x);
        anim.SetFloat("vely", movement.y);
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(movement.x, 0f, movement.y);
        Vector3 cameraDir = WorldToCameraSpace(dir);
        rb.MovePosition(rb.transform.position + cameraDir.normalized * 0.1f);

        Vector3 lookDir = WorldToCameraSpace(Vector3.forward);
        Quaternion lookRotation = Quaternion.LookRotation(lookDir.normalized, rb.transform.up);
        float diffRotation = lookRotation.eulerAngles.y - rb.transform.eulerAngles.y;
        float eulerY = rb.transform.eulerAngles.y;

        if (diffRotation > 0f || diffRotation < 0f)
        {
            eulerY = lookRotation.eulerAngles.y;
        }
        Vector3 eulerRotation = new Vector3(0, eulerY, 0);
        rb.MoveRotation(Quaternion.Euler(eulerRotation));
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            rb.transform.position = startingPosition;
        }
    }

    private Vector3 WorldToCameraSpace(Vector3 v)
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 forward = v.z * cameraForward;
        Vector3 right = v.x * cameraRight;

        return forward + right;
    }
}
