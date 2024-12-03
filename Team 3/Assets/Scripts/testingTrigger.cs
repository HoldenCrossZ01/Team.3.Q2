using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnityEvent onTriggerEnter2D;
    [SerializeField] UnityEvent onTriggerExit2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter2D.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExit2D.Invoke();
    }

}
