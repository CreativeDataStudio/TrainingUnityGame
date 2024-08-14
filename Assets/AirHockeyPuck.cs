using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHockeyPuck : MonoBehaviour
{

    AudioSource ping;
    public AudioClip Audio;

    private void Start()
    {
        ping = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ping.PlayOneShot(Audio);
    }


}
