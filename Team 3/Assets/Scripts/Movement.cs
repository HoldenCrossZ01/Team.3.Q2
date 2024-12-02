using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Movement : MonoBehaviour
{
    public float distanceBetween;
    //public GameObject Enemy;
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S, Jump = KeyCode.Space;
    public float speed = 10, jumpHeight = 15;
    private float distance;
    private Rigidbody2D _rb;
    public bool looking = true;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetKey(); is for HOLDING a key
        //Input.GetKeyDown(); is for PRESSING a key
        //Input.GetKeyUp(); is for RELEASING a key

        //distance = Vector2.Distance(transform.position, Enemy.transform.position);

        if (Input.GetKey(left)) //chek for the player holding down the left button
        {
            _rb.velocity = Vector2.left * speed; //get the component to the ri
        }

        if (Input.GetKey(right)) // check to be holding down the right button
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }

        if (Input.GetKey(up)) //chek for the player holding down the up button
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }

        if (Input.GetKey(down)) //chek for the player holding down the up down button
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        }

        if (Input.GetKeyDown(Jump))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpHeight;
        }

        // if (Input.GetKeyDown(KeyCode.Y))
        //{
        // GetComponent<Rigidbody2D>() .Gravity Scale *= -1; 
        //}

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = 0.0f;
            SceneManager.LoadScene("gameover");
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}

