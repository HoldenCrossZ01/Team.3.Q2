using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class MoveSpeed : MonoBehaviour
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
          rb.velocity = input  * moveSpeed;
    }

    private void GetInput()
    {
       // x = Input.GetAxisRaw("Horizontal");
       x = this.gameObject.transform.position.x; //fix
      //  y = Input.GetAxisRaw("Vertical");
       y = this.gameObject.transform.position.y; //fix

        input = new Vector2(x, y);
        input.Normalize();
    }
    private void Animate()
    {
        if(newposition != oldposition) //|| input.magnitude < -0.1f)
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
