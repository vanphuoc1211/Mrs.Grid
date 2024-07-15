using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Item : MonoBehaviour
{
    public float healAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if(playerController  !=  null)
        {
            if(playerController.health <100)
            {
                playerController.Addhealth(healAmount);
                gameObject.SetActive(false);
            }
        }
    }
}
