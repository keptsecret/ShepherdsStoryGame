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
    private AudioSource audioSource;

    // for jumping
    private bool isJumping = false;
    private float jumpForce = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        startingPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        anim.SetFloat("velx", movement.x);
        anim.SetFloat("vely", movement.y);
        DetectJumpPhases();

        if (rb.transform.position.y < -20) 
        {
            rb.transform.position = startingPosition;
        }
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

    void OnJump(InputValue value)
    {
        //Debug.Log("Jump");
        if (value.Get<float>() > 0f && !isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        anim.SetBool("IsJumpingUp", true);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsFalling", false);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }

    private void DetectJumpPhases()
    {
        if (isJumping)
        {
            if (rb.velocity.y > 0)
            {
                anim.SetTrigger("jumpup");
                anim.SetBool("IsJumpingUp", true);
                //anim.SetBool("IsMidAir", false);
                anim.SetBool("IsFalling", false);
                anim.SetBool("IsWalking", false);
            }
            else
            {
                anim.ResetTrigger("jumpup");
                //Debug.Log("falling");
                anim.SetBool("IsJumpingUp", false);
                //anim.SetBool("IsMidAir", false);
                anim.SetBool("IsFalling", true);
                anim.SetBool("IsWalking", false);

            }
        } else
        {
            anim.SetTrigger("walking");
            //Debug.Log("walk");
            anim.SetBool("IsJumpingUp", false);
            //anim.SetBool("IsMidAir", false);
            anim.SetBool("IsFalling", false);
            anim.SetBool("IsWalking", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            rb.transform.position = startingPosition;
        }
        if (other.gameObject.tag == "Terrain")
        {
            Debug.Log("collided with terrain");
            //Debug.Log("Walk");
            isJumping = false;
            anim.SetBool("IsWalking", true);
            anim.SetTrigger("walking");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
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

    private void PlayerFootstepSound()
    {
        audioSource.Play();
    }
}
