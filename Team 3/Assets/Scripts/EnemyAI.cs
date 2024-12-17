using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Runtime.InteropServices.WindowsRuntime;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Transform route;

    private GameObject player;
    [SerializeField] GameObject target1;
    private float distance1;
    public bool tsuki1;
    private bool targe1Exist = true;
    [SerializeField] GameObject Cone;
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

    public float Timer = 3.0f;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Transform enemyGFX;
    
    
    public float distanceBetween;
    private float distanced;
    private float distance;
    public float distancebetweentarget;


Path path;
    int currentWaypoint = 0;
    bool reachedEndOdPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        
        seeker = GetComponent<Seeker>();
        tsuki1 = true ;
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
        distanced = Vector2.Distance(transform.position, player.transform.position);
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
        
        distance1 = Vector2.Distance(transform.position, target1.transform.position);
        distance2 = Vector2.Distance(transform.position, target2.transform.position);
        distance3 = Vector2.Distance(transform.position, target3.transform.position);
        distance4 = Vector2.Distance(transform.position, target4.transform.position);
        targe1Exist = true;

        if (distanced < distanceBetween && hasLineOfSight)
        {
            target = player.transform;
            distanceBetween = 7;
            speed = 1500;
            Cone.SetActive(false);

        }

        if (tsuki1 = true && distanced > distanceBetween)
        {
           // target = target1.transform;
            speed = 600;
            Cone.SetActive(true);
            distanceBetween = 4;
            tsuki1 =false;
        }
        if (distance1 < distancebetweentarget && distanced > distanceBetween)
        {
            StartCoroutine (SpawnDelay());

        }
        if (tsuki1 = false && distanced < distanceBetween) 
        { 
      //  target1 = 
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
    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(3);
        target = target2.transform;
    }

}