using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iamsmoves : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    public float x;
    public float y;

    public Animator anim;
    private bool moving;
    
    private Vector2 input;

    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GetInput();
        animate();
    }
    private void fixadeUpdate()
    {
        rb.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }
    private void animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < 0.1f)
        {
            moving = true;
        }
        else { 
        moving = false;
        }

        if (moving) { 
            anim.SetFloat("x", x);
            anim.SetFloat("y", y);
        }

        anim.SetBool("Moving", moving);
    }

}
