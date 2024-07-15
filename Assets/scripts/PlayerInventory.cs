using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public int NumberofCoins{get;private set;}
    public UnityEvent<PlayerInventory> OnCoinCollected;
    public void CoinCollected(int level)
    {
        source.PlayOneShot(clip);
        NumberofCoins += level*100;
        OnCoinCollected.Invoke(this);
    }

}
