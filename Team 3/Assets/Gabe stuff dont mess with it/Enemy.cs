using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject Target;
    [SerializeField] public float speed = 1.5f;
    public float distanceBetween;
    private bool hasLineOfSight = false;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;



        if (distance < distanceBetween && hasLineOfSight)
            {
              transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
              transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        if (distance < distanceBetween && !hasLineOfSight)
        {
            
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            if (hasLineOfSight)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
}
