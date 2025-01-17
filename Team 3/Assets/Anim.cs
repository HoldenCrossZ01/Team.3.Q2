using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    private Animator _anim;
    private AIDestinationSetter _destination;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _destination = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = _destination.target.position - transform.position;

        _anim.SetFloat("X", direction.x);
        _anim.SetFloat("Y", direction.y);
        _anim.SetBool("Moving", direction.magnitude > 0);
    }
}
