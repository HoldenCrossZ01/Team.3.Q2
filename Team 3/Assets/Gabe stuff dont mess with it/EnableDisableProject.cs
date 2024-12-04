using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableDisableProject : MonoBehaviour
{
    BoxCollider2D _col;
    void Start()
    {
        _col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _col.enabled = false;
        }
    }
    //stopped at 4:03 min
}
