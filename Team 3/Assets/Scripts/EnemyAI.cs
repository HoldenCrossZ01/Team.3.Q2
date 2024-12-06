using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Runtime.InteropServices.WindowsRuntime;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    
    //
    private GameObject player;
    private GameObject pathe;
    // distance method up
    private bool hasLineOfSight = false;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Transform enemyGFX;
    
    //remove
    public float distanceBetween;
    private float distance;
    //end remove


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
        pathe = GameObject.FindGameObjectWithTag("pathe");
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

        #region
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < distanceBetween && hasLineOfSight)
        {
            target = player.transform;
        }
        if (distance > distanceBetween)
        {
            target = pathe.transform;
        }
        #endregion

    }
}
