using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : MonoBehaviour
{
    public Animator anim;

public float moveSpeed;
private Rigidbody2D rb;

private float x;
private float y;

    private Vector2 input;
    private bool Moving;
    void Start()
    {

    }
    private void Update()
    {
        GetInput();
        Animate();
    }
    private void FixedUpdate()
    {
        rb.velocity = input  * moveSpeed;
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }
    private void Animate()
    {
        if(input.magnitude >0.1f || input.magnitude < -0.1f)
        {
            Moving = true;
        }
        else {Moving = false; }

        if (Moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", Moving);
    }
}
