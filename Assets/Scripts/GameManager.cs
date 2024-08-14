using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreLabel;

    int score = 0;

    public void AddPoints(int points)
    {
        score += points;

        Debug.Log($"The score is: {score}");

        scoreLabel.text = $"{score} POINTS";
    }
}
