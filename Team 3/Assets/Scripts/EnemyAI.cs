using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Runtime.InteropServices.WindowsRuntime;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    
    private GameObject player;
    [SerializeField] GameObject target1;
    [SerializeField] GameObject Cone;
    private bool hasLineOfSight = false;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Transform enemyGFX;
    
    
    public float distanceBetween;
    private float distance;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOdPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        seeker.StartPath(rb.position, target.position, OnPathComplete);
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("UpdatePath", 0f, .5f);
    }
    
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count) { 
            reachedEndOdPath = true;
            return;
        } else
        {
            reachedEndOdPath = false;
        }
        

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb.velocity.y >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.y <= -0.01f) 
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < distanceBetween && hasLineOfSight)
        {
            target = player.transform;
            distanceBetween = 7;
            speed = 1200;
            Cone.SetActive(false);

        }
        if (distance > distanceBetween)
        {
            target = target1.transform;
            speed = 600;
            Cone.SetActive(true);
            distanceBetween = 3;
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