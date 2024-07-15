using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource source;
    public AudioClip BackgroundClip;

    void Start()
    {
        source.clip = BackgroundClip;
        source.Play();
    }
}
