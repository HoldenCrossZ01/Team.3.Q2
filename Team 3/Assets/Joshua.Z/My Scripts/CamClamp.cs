using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamClamp : MonoBehaviour
{

    [SerializeField]
    private Transform targetToFollow;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, -10000, 10000),
            Mathf.Clamp(targetToFollow.position.y, 10, 15),
            transform.position.z);

    }

}
