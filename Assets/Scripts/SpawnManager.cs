using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    private int enemyCount;
    private int waveNumber = 5;
    private float spawnPosition = 50.0f;
    private GameManager gameManager;


    // Add boundaries for each individual plane later
    // Add multiple planes
    // Add better AI


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

          InvokeRepeating("ConstantEnemySpawn", 1, 12);
          InvokeRepeating("WaveNumberIncrease", 1, 60);

          if (!gameManager.isGameOver && gameManager.isPlayButtonClicked)
          {
           ConstantEnemySpawn();
           WaveNumberIncrease();
          }
            
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (gameManager.isGameOver)
        {
            CancelInvoke();
            gameManager.GameOver();
        }
    }

    private void ConstantEnemySpawn()
    {
         for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyPrefab, GeneratePlanePosition(), enemyPrefab.transform.rotation);
        }
    }

    private void WaveNumberIncrease()
    {
        waveNumber++;
    }

    private Vector3 GeneratePlanePosition()
    {
        float spawnX = Random.Range(-spawnPosition, spawnPosition);
        float spawnZ = Random.Range(-spawnPosition, spawnPosition);
        Vector3 planeRadius = new Vector3(spawnX, .51f, spawnZ);

            return planeRadius;
        
    }
}
