using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    float moveLimiter = 0.7f;
    public Rigidbody2D rb;
    Vector2 movement;

    private void Start()
    {
        //keep this??
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Need to limit diagonal movespeed
        if (movement.x != 0 && movement.y != 0)
        {
            // Move at 70% speed diagonally
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    // maybe change fixedupdate to late update



}