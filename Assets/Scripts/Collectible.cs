using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public Action OnPlayerPickup;

    private void OnTriggerEnter(Collider other)
    {
        OnPlayerPickup.Invoke();

        GetComponentInChildren<AudioSource>().Play();

        StartCoroutine(PlayAudioAndDestroy());
    }

    private IEnumerator PlayAudioAndDestroy()
    {
        AudioSource audioSource = GetComponentInChildren<AudioSource>();

        // Play the audio
        audioSource.Play();

        // Hide the object
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;

        //yield return new WaitForSeconds(10); // 10 second wait

        // Wait until the audio has finished playing
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Destroy the GameObject after the audio is finished
        Destroy(gameObject);
    }

}
