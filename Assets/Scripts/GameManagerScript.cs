using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject apple, pineapple;
    public float powerSpawnHeight = 1f;

    public float powerDelay = 5;
    public float powerRate = 5;

    private bool powerup = false;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", powerDelay, powerRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn() {
        Vector2 position = new Vector2(Random.Range(-7.0f, 7.0f), powerSpawnHeight);
        if (powerup) {
            Instantiate(apple, position, Quaternion.identity );
            powerup = false;
        } else {
            Instantiate(pineapple, position, Quaternion.identity );
            powerup = true;
        }
    }
}
