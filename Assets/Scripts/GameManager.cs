using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float SpawnExtends;
    public int CollectibleCount = 20;
    public Collectible CollectiblePrefab;

    public TMP_Text ScoreLabel;

    int score = 0;

    private void Start()
    {
        SpawnCollectibles();
    }

    public void AddPoints(int points)
    {
        score += points;

        Debug.Log($"The score is: {score}");

        ScoreLabel.text = $"{score} POINTS";
    }

    public void SpawnCollectibles()
    {
        for(int i = 0; i < CollectibleCount; i++)
        {
            float randomX = Random.Range(-SpawnExtends, SpawnExtends);
            float randomZ = Random.Range(-SpawnExtends, SpawnExtends);

            Vector3 spawnLocation = new Vector3(randomX, 0.5f, randomZ);

            Collectible c = Instantiate(CollectiblePrefab, spawnLocation, Quaternion.identity);

            c.OnPlayerPickup += HandlePickupCollectible;
        }
    }

    void HandlePickupCollectible()
    {
        AddPoints(5);
    }

}
