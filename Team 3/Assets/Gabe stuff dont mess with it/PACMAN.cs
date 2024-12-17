using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PACMAN : MonoBehaviour
{
    
    public Transform pacman;
    [SerializeField] GameObject target1;
    private float distance1;
    public bool targe1Exist = true;
    [SerializeField] GameObject target2;
    private float distance2;
    public bool targe2Exist;
    [SerializeField] GameObject target3;
    public bool targe3Exist;
    private float distance3;
    [SerializeField] GameObject target4;
    public bool targe4Exist;
    private float distance4;
    private bool hasLineOfSight = false;
    [SerializeField] GameObject Tsuki;

    public float distanceBetween;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance1 = Vector2.Distance(Tsuki.transform.position, target1.transform.position);
        distance2 = Vector2.Distance(Tsuki.transform.position, target2.transform.position);
        distance3 = Vector2.Distance(Tsuki.transform.position, target3.transform.position);
        distance4 = Vector2.Distance(Tsuki.transform.position, target4.transform.position);

        if (distance1 < distanceBetween)
        {
            pacman = target2.transform;
        }

    }
}
