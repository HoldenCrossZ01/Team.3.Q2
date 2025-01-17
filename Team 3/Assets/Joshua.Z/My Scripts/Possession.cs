using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
   public float Radius = 1f;
    public LayerMask Layer;
    public bool CanPossessIam;
    public bool CanPossessElse;
    public bool IsCurrentlyPossessed;

    void Update()
    {
        var hits = Physics2D.CircleCastAll(transform.position, Radius, Vector2.zero, 0, Layer);

        // Only for objects.
        if (IsCurrentlyPossessed && CanPossessIam == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");

                Debug.Log("Pressing Space");

                Debug.Log("Possessed");

                player.GetComponent<PlayerCtrlLectI>().enabled = true;
                GetComponent<PlayerCtrlLectI>().enabled = false;

                IsCurrentlyPossessed = false;
                player.GetComponent<Possession>().IsCurrentlyPossessed = true;
                FindObjectOfType<CamDrag>().target = player.transform;
            }
        }

        foreach (var hit in hits)
        {
            if (hit.transform == transform)
                continue;

            // Only for Iam.
            if (IsCurrentlyPossessed && CanPossessElse == true)
            {
                if (hit.transform.TryGetComponent(out ParticleSystem particleSystem))
                {
                    particleSystem.Emit(1);
                }

                if (hit.transform.CompareTag("PossessableObject") && hit.transform.TryGetComponent(out PlayerCtrlLectI control))
                {
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        Debug.Log("Pressing Space");

                        Debug.Log("Possessed");

                        control.enabled = true;
                        GetComponent<PlayerCtrlLectI>().enabled = false;

                        IsCurrentlyPossessed = false;
                        hit.transform.gameObject.GetComponent<Possession>().IsCurrentlyPossessed = true;

                        FindObjectOfType<CamDrag>().target = hit.transform;
                    }
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
