using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnableDisableProject : MonoBehaviour
{
    public KeyCode phase = KeyCode.P;

    BoxCollider2D _col;
    private bool apple = true;
    void Start()
    {
        _col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (apple = true && Input.GetKeyDown(phase))
        {
            //_col.enabled = !_col.enabled;
            apple = false;
            this.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
            Debug.Log(apple);
        }
        if (apple = true && Input.GetKeyUp(phase))
        {
            Debug.Log(apple);
            this.gameObject.layer = LayerMask.NameToLayer("Default");
            apple = true;
            Debug.Log(apple);
        }
    }
}
