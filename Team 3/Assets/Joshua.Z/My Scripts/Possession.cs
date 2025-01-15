using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
   public float Radius = 1f;
    public LayerMask Layer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var hit = Physics2D.CircleCast(transform.position, Radius, Vector2.zero, 0, Layer);

            if (hit && hit.transform.TryGetComponent(out PlayerCtrlLectI control))
            {
                control.enabled = true;
                GetComponent<PlayerCtrlLectI>().enabled = false;
            }

            //if (Input.GetKeyUp(KeyCode.L))
            //{
            //    control.enabled = false;
            //    GetComponent<PlayerCtrlLectI>().enabled = true;
            //}

        }

        

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
