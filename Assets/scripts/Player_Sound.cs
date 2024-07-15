using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_Sound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] audioClip;
    public AudioClip LandingSound;

    void footSound()
    {
        AudioClip clip = GetRandomClip();
        source.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0,audioClip.Length -1 );
        return audioClip[index];
    }
    void landingSound()
    {
        source.clip = LandingSound;
        source.Play();
    }
}
