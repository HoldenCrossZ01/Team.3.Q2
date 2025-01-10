using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName:"Open")]
    void Update()
    {
        _animator.SetTrigger(name: "Open");
    }




}
