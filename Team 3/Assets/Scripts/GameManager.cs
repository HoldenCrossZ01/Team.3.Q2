using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
//game manager is to generalize things, its goint to allow us to code wayyy more faster, i can teach u a little bit about its benefits
public class GameManager : MonoBehaviour
{
    #region this is for trigger condition for the A.I to change its target
    [Tooltip("Object that enters this trigger must have this tag.")]
    public string requiredTag = "Player";

    public UnityEvent onTriggerEnter = new UnityEvent();
    public UnityEvent onTriggerExit = new UnityEvent();


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(requiredTag)) onTriggerEnter.Invoke();
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag)) onTriggerExit.Invoke();
    }
    #endregion //ends here

}
