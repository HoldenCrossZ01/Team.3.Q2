using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iamsmoves : MonoBehaviour
{
    public Animator anim;

    public float moveSpeed;
    private Rigidbody2D rb;

    private float x;
    private float y;
    private float startposition;
    private Vector2 input;
    private bool Moving;
    private Vector2 oldposition;
    private Vector2 newposition;
    void Start()
    {

    }
    private void Update()
    {


        newposition = transform.position;

        GetInput();


        Animate();
        startposition = Vector2.Distance(newposition, oldposition);
        oldposition = transform.position;

    }
    private void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        Vector2 velocity = newposition - oldposition;

         x = Input.GetAxisRaw("Horizontal");
         y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }
    private void Animate()
    {
        if (input.magnitude < 0.1f|| input.magnitude < -0.1f)
        {
            Moving = true;
        }
        else { Moving = false; }

        if (Moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", Moving);
    }

    private IEnumerator CheckMoving()
    {
        Vector3 startPos = this.gameObject.transform.position;
        yield return new WaitForSeconds(1f);
        Vector3 finalPos = this.gameObject.transform.position;

        if (startPos.x != finalPos.x || startPos.y != finalPos.y
            || startPos.z != finalPos.z)
            Moving = true;

    }
}
