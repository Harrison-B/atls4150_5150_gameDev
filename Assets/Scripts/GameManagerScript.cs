using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject apple, pineapple, blueEnemy, greenEnemy, redEnemy;
    public float powerSpawnHeight = 1f;

    public float spawnHeight = 5f;

    public float enemyDelay = 2;
    public float enemyRate = 2;

    public float powerDelay = 5;
    public float powerRate = 5;

    public float gameProgress = 0;



    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnPowerup", powerDelay, powerRate);
        // InvokeRepeating("SpawnEnemy", enemyDelay, enemyRate);
        Invoke("SpawnPowerup", 5f);
        Invoke("SpawnBlueEnemy", 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameProgress++;

        if (gameProgress == 1000) {
            enemyRate = 4;
        } else if (gameProgress == 3000) {
            enemyRate = 3;
            Invoke("SpawnGreenEnemy", 2f);
        } else if (gameProgress == 5000) {
            enemyRate = 2;
            Invoke("SpawnRedEnemy", 2f);
        } else if (gameProgress == 80000) {
            enemyRate = 1;
        }
    }

    private void SpawnPowerup() {
        Vector2 position = new Vector2(Random.Range(-7.0f, 7.0f), powerSpawnHeight);

        int randPower = Random.Range(0,100);
        if (randPower > 50) {
            Instantiate(apple, position, Quaternion.identity );
        } else if (randPower <= 50) {
            Instantiate(pineapple, position, Quaternion.identity );
        }

        Invoke("SpawnPowerup", powerDelay);
    }

    private void SpawnBlueEnemy() {
        Vector2 position = new Vector2(Random.Range(-8.0f, 8.0f), spawnHeight);
        Instantiate(blueEnemy, position, Quaternion.identity );

        Invoke("SpawnBlueEnemy", enemyDelay);
    }

    private void SpawnGreenEnemy() {
        Vector2 position = new Vector2(Random.Range(-8.0f, 8.0f), spawnHeight);
        Instantiate(greenEnemy, position, Quaternion.identity );

        Invoke("SpawnGreenEnemy", enemyDelay);
    }

    private void SpawnRedEnemy() {
        Vector2 position = new Vector2(Random.Range(-8.0f, 8.0f), spawnHeight);
        Instantiate(redEnemy, position, Quaternion.identity );

        Invoke("SpawnRedEnemy", enemyDelay);
    }
}
