using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHockeyGoal : MonoBehaviour
{
    private AudioSource audioSource;
    public AirHockeyGameManager GameManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        GameManager.OnGoalScored();
    }
}
