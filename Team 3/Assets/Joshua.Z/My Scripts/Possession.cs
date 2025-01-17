using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
   public float Radius = 1f;
    public LayerMask Layer;
    public bool CanPossessIam;
    public bool CanPossessElse;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (CanPossessIam == true)
            {
                Debug.Log("Pressing Space");

                var hit = Physics2D.CircleCast(transform.position, Radius, Vector2.zero, 0, Layer);

                if (hit && GameObject.FindGameObjectWithTag("Player") && hit.transform.TryGetComponent(out PlayerCtrlLectI control) && hit.transform != transform)
                {
                    Debug.Log("Possessed");

                    control.enabled = true;
                    GetComponent<PlayerCtrlLectI>().enabled = false;

                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (CanPossessElse == true)
            {
                Debug.Log("Pressing Space");

                var hit = Physics2D.CircleCast(transform.position, Radius, Vector2.zero, 0, Layer);

                if (hit && GameObject.FindGameObjectWithTag("PossessableObject") && hit.transform.TryGetComponent(out PlayerCtrlLectI control) && hit.transform != transform)
                {
                    Debug.Log("Possessed");

                    control.enabled = true;
                    GetComponent<PlayerCtrlLectI>().enabled = false;

                }
            }
        }


    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

    //Debug.Log("Pressing Space");

    //var hit = Physics2D.CircleCast(transform.position, Radius, Vector2.zero, 0, Layer);

    //if (hit && GameObject.FindGameObjectWithTag("Player") && hit.transform.TryGetComponent(out PlayerCtrlLectI control) && hit.transform != transform)
    //{
    //    Debug.Log("Possessed");

    //    control.enabled = true;
    //    GetComponent<PlayerCtrlLectI>().enabled = false;


    //}

    //if (Input.GetKeyUp(KeyCode.L))
    //{
    //    control.enabled = false;
    //    GetComponent<PlayerCtrlLectI>().enabled = true;
    //}

}
