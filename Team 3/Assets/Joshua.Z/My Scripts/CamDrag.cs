using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDrag : MonoBehaviour
{
    public float speed;
    public Vector3 offset;

    private Transform target;
    //public GameObject ToFollow;

    void Start()
    {
        //target = GameObject..GetComponent<Transform>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

   
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position + offset, speed * Time.deltaTime);
    }
}
