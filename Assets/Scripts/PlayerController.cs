using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(movement.x, 0f, movement.y);
        Vector3 dirCamera = WorldToCameraSpace(dir);
        rb.MovePosition(rb.transform.position + dirCamera.normalized * 0.25f);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
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
