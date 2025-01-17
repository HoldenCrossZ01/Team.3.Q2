using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrlLectI : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D rb;
    private Animator _anim;

    private float x;
    private float y;

    private Vector2 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }
    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();

        _anim.SetFloat("X", x);
        _anim.SetFloat("Y", y);
        _anim.SetBool("Moving", input.magnitude > 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;
            SceneManager.LoadScene("gameover");
        }
    }
}
