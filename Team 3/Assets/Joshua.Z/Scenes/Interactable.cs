using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent Interact;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Vector2 PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector2 ItemPosition = transform.position;

            if (Vector2.Distance(PlayerPosition, ItemPosition)<3)
            {
                Interact.Invoke();   
            }
        }
    }
}
