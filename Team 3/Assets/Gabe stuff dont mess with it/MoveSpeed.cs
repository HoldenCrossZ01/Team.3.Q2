using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : MonoBehaviour
{
public float moveSpeed;
public Rigidbody2D rb;

public float x;
public float y;
    void Start()
    {

    }
    private void Update()
    {
        GetInput();   
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(x * moveSpeed,y * moveSpeed);
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }
}
