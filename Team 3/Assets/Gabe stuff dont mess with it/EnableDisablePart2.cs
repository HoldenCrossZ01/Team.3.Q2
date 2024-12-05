using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisablePart2 : MonoBehaviour
{
    private float distance;
    public float distanceBetween;
    public GameObject player;
    [SerializeField] GameObject _squareParents;
    [SerializeField] GameObject _square;
    void Start()
    {
        
    }

    void Update()
    {
        distance = Vector2.Distance(_squareParents.transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.K) && distance < distanceBetween)
        {
            _squareParents.SetActive(false);
        }
    }
}
