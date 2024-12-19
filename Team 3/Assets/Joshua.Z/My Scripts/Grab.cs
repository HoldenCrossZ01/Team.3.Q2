using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{


    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    public KeyCode grab = KeyCode.O;
    [SerializeField] GameObject hidden;

    BoxCollider2D _col;
    BoxCollider2D _coler;
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("GrabableObjects");
        _col = hidden.gameObject.GetComponent<BoxCollider2D>();
        _coler = gameObject.GetComponent<BoxCollider2D>();
    }
    
        
    

   
    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex)
        {

            if (Input.GetKeyDown(grab) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);

            }

            else if (Input.GetKeyUp(grab))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                _coler.enabled = true;
            }

        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);

    }
}
