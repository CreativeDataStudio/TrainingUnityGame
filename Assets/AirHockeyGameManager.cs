using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AirHockeyGameManager : MonoBehaviour
{
    public Rigidbody Puck;
    public TMP_Text scoreLabel;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Puck.AddForce(new Vector3(1, 0, 0.5f) * 2, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoalScored()
    {
        score++;

        scoreLabel.text = score > 1 ? $"{score} POINTS" : $"{score} POINT";
    }
}
