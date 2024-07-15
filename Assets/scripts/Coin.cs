using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int level;
    public void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory !=  null)
        {
            playerInventory.CoinCollected(level);
            gameObject.SetActive(false);
        }
    }
}
