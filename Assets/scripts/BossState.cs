using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    public GameObject door;
    public Animator Anim;
    private Transform player;
    public float dist,sightRange,attackRange; 
    public float health;
    private float test;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Anim = GetComponent<Animator>();
    }

    
    public void Walk()
    {
        Anim.SetBool("Walk",true);
        Anim.SetBool("Attack",false);
        Anim.SetBool("TakeDamage",false);
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

        test = health;
        health -= amounce; 
    }

    private void Update()
    {
        
        Anim.SetBool("Attack",false);
        dist = Vector3.Distance(player.position, transform.position);
        if(health < test)
        {
            test = health;
            Anim.SetBool("Walk",false);
            Anim.SetBool("Attack",false);
            Anim.SetBool("TakeDamage",true); 
            if(health <60 && health>0)
            {
                Anim.SetBool("TakeDamage",false); 
                Anim.SetBool("Skill",true);
            }
            else if(health<0)
            {
                door.SetActive(false);
                Anim.SetBool("Dead",true);
                StartCoroutine(WaitForSceneLoad());
            }
        }
        else
        {
            Anim.SetBool("Skill",false);
            Anim.SetBool("TakeDamage",false);
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
        }
        
    }
    private IEnumerator WaitForSceneLoad() 
	{
		yield return new WaitForSeconds(5);
		Destroy(gameObject);
 	}

}
