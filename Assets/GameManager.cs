using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;

    public void AddPoints(int points)
    {
        score += points;

        Debug.Log($"The score is: {score}");
    }
}
