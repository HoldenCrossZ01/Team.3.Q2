using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagDrag : MonoBehaviour
{
    public float speed;
    private Transform target;
    //public GameObject ToFollow;

    void Start()
    {
        //target = GameObject..GetComponent<Transform>();

        target = GameObject.FindGameObjectWithTag("BagDestination").GetComponent<Transform>();
    }

   
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
   
}
