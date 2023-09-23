using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movement;

    private int score;
    public int SheepCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (score == SheepCount)
        {
            Debug.Log("Win!");
        }
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(movement.x, 0f, movement.y);
        rb.MovePosition(rb.transform.position + dir.normalized * 0.25f);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void IncrementScore()
    {
        score++;
    }
}
