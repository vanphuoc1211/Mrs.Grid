using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public void Addheath(float amounce)
    {
        health += amounce;
    }
    public void DiscreasedHealth(float amounce)
    {
        health -= amounce;
        Debug.Log("Heatlh Decreased, current health "+ health);
        if(health <= 0 )
        {
            Debug.Log("PlayerisDead");
        }
    }
}
