using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public Animator Anim;
    private Transform player;
    public float dist,sightRange,attackRange; 
    public float health;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Anim = GetComponent<Animator>();
    }

    
    public void Walk()
    {
        Anim.SetBool("Walk",true);
        Anim.SetBool("Attack",false);
    }

    public void Attack()
    {
        Anim.SetBool("Attack",true);
    }
    public void Idle()
    {
        Anim.SetBool("Walk",false);
        Anim.SetBool("Attack",false);
    }

    public void DiscreasedHealth(float amounce)
    {
        health -= amounce; 
    }

    private void Update()
    {
        Anim.SetBool("Attack",false);
        dist = Vector3.Distance(player.position, transform.position);
        if(dist <= attackRange)
        {
            Attack();
        }
        if(dist > sightRange)
        {
            Idle();
        }
        if(dist <sightRange && dist > attackRange)
        {
            Walk();
        }
        if(health <= 0)
        {
            Anim.SetBool("Walk",false);
            Anim.SetBool("Attack",false);
            Anim.SetBool("Dead",true);
        }
    }

}
