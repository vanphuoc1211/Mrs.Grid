
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public LayerMask WhatIsGround,WhatIsPlayer;
    
    //Patrolling
    public Vector3 Walkpoint;
    bool WalkpointSet;
    public float WalkpointRange;

    //States
    public float sightRange,attackRange;
    public bool playerInSightRange,playerInAttackRange;
    
    public float health;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange,WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position,attackRange,WhatIsPlayer);
        if(!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }
        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patrolling()
    {
        if(!WalkpointSet)
        {
            SearchWalkpoint();
        }

        if(WalkpointSet)
        {
            navMeshAgent.SetDestination(Walkpoint);
        }

        Vector3 distanceToWalkPoint = transform.position - Walkpoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            WalkpointSet = false;
        }
    }

    private void SearchWalkpoint()
    {
        float randomZ = Random.Range(-WalkpointRange,WalkpointRange);
        float randomX = Random.Range(-WalkpointRange,WalkpointRange);

        Walkpoint = new Vector3(transform.position.x + randomX, transform.position.y,transform.position.z + randomZ);
        if(Physics.Raycast(Walkpoint, -transform.up,2f,WhatIsGround))
        {
            WalkpointSet = true;
        }
    }

    private void ChasePlayer()
    {
        transform.LookAt(player);
        navMeshAgent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        transform.LookAt(player);
    }

    public void DiscreasedHealth(float amounce)
    {
        health -= amounce;
        if(health <= 0)
        {
            Invoke(nameof(DestroyEnemy),2f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
