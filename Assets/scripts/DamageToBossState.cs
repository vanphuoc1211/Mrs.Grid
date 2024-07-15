using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToBossState : MonoBehaviour
{
    public float damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        BossState bossState = other.GetComponent<BossState>();
        if(bossState  !=  null)
        {
            if(bossState.health >= 0)
            {
                bossState.DiscreasedHealth(damageAmount);
            }
        }

    }
}
