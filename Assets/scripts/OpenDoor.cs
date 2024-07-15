using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{ 
    private float speed = 2.0f;
    public GameObject door;
    public AudioSource source;
    public AudioClip opendoor;

    public void  OnTriggerEnter(Collider other)
    {
        source.clip =  opendoor;
        source.Play();
    }
    public void OnTriggerStay(Collider other)
    {   
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory != null)
        {
           door.transform.Translate(0,0,-speed*Time.deltaTime);
        }
    }

    public void  OnTriggerExit(Collider other)
    {
        source.clip  = null;
    }
}
