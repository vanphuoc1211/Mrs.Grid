using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdown : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory !=  null)
        {
            gameObject.SetActive(false);
        }
    }
}
