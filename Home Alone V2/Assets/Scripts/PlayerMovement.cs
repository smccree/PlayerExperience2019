using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove;
    public GameObject Player;

    Vector2 movement;

    void Start()
    {
        canMove = true;
        speed = 5f; //initialize speed
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (canMove == true)
        { 
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("speed", movement.sqrMagnitude);
        }
        else
        {
            movement.x = 0; movement.y = 0;
        }
        
    }

    void FixedUpdate()
    {
        // Movement - constant movement speed
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
