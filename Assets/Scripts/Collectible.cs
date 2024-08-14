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
        Destroy(gameObject);
    }

}
