using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement1 : MonoBehaviour
{
   
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S;
    public float speed = 10;
    
    private Rigidbody2D _rb;
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
        //7
        
        if (Input.GetKey(left)) //check for the player holding down the left button
        {
            _rb.velocity = Vector2.left * speed; //get the component to the right
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

      
        
        
        // if (Input.GetKeyDown(KeyCode.Y))
        //{
        // GetComponent<Rigidbody2D>() .Gravity Scale *= -1; 
        //}
    }
}
