using Pathfinding.Ionic.Zip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GuardsLightWork : MonoBehaviour
{
    [SerializeField] GameObject Uplight;
    [SerializeField] GameObject downlight;
    [SerializeField] GameObject leftlight;
    [SerializeField] GameObject rightlight;
    private Vector2 oldposition;
    private Vector2 newposition;
    public float x;
    public float y;
    public float x_math;
    public float y_math;
    // Update is called once per frame
    private void Start()
    {
        leftlight.SetActive(false);
        Uplight.SetActive(false);
        downlight.SetActive(false);
        rightlight.SetActive(false);
    }

    void Update()
    {
        newposition = transform.position;
        
        GetInput();
        
        if (x <= -0.1 && y_math > x_math)
        {
            leftlight.SetActive(true);
            Uplight.SetActive(false);
            downlight.SetActive(false);
            rightlight.SetActive(false);
        }
        else if (y <= -0.1 && x_math > y_math)
        {
            downlight.SetActive(true);
            rightlight.SetActive(false);
            Uplight.SetActive(false);
            leftlight.SetActive(false);
        }
        else if (x >= 0.1 && y_math > x_math)
        {
            rightlight.SetActive(true);
            leftlight.SetActive(false);
            Uplight.SetActive (false);
            downlight.SetActive (false);
        }


        oldposition = transform.position;

    }
    private void GetInput()
    {
        Vector2 velocity = newposition - oldposition;
        // x = Input.GetAxisRaw("Horizontal");
        x = velocity.x; //fix
                        //  y = Input.GetAxisRaw("Vertical");
        y = velocity.y; //fix

        y_math = x - y;
        x_math = y - x;
    }

}
