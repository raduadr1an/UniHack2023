using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator animator;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    public Camera cam;
    private Vector2 mousePos;

    public float moveSpeed = 20.0f;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            animator.SetBool("isWalking", (horizontal != 0 || vertical != 0) ? true : false);
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
            body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
            Vector2 lookDir = mousePos - body.position;

            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            sprite.flipX = (angle < 0f && angle > -180f) ? false : true;
        }

        //Debug.Log(angle);
    }
}