using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        
        if(playerController  !=  null)
        {
            if(playerController.health >= 0)
            {
                playerController.DiscreasedHealth(damageAmount);
            }
        }

    }
}
