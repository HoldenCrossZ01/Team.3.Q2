using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    
    public GameObject door;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //transform.position = collision.gameObject.transform.Translate(Vector2.down);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
