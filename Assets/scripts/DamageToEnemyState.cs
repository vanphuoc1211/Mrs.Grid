using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemyState : MonoBehaviour
{
    public float damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        EnemyState enemyState = other.GetComponent<EnemyState>();
        if(enemyState  !=  null)
        {
            if(enemyState.health >= 0)
            {
                enemyState.DiscreasedHealth(damageAmount);
            }
        }

    }
}
