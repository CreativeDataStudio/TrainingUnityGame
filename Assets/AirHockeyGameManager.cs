using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHockeyGameManager : MonoBehaviour
{
    public Rigidbody Puck;


    // Start is called before the first frame update
    void Start()
    {
        Puck.AddForce(Vector3.forward * -2, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
