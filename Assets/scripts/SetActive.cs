using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject Rock;
    public void OnTriggerStay(Collider other)
    {   
        
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory != null)
        {
            Rock.SetActive(true);
        }
    }
}
