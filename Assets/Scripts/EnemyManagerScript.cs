using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour {
    public GameObject blueEnemy, redEnemy, greenEnemy;
    public Color[] brickColors;

    public float xSpacing, ySpacing;
    public float xOrigin, yOrigin;
    public int numRows, numColumns;

    public float spawnHeight = 1f;

    public float delay = 2;
    public float rate = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);


        // for (int i = 0; i < numRows; i++) {
        //     for (int j = 0; j < numColumns; j++) {
        //         Transform go = Instantiate(brick);
        //         go.transform.parent = this.transform;
                
        //         Vector2 loc = new Vector2(xOrigin + (i * xSpacing), yOrigin - (j * ySpacing));
        //         go.transform.position = loc;

        //         SpriteRenderer sr = go.GetComponent<SpriteRenderer>();                
        //     }
        // }
    }

    private void Spawn() {
        // int i = Random.Range(0,100);
        // if (i>10) {
            Vector2 position = new Vector2(Random.Range(-8.0f, 8.0f), spawnHeight);
            Instantiate(blueEnemy, position, Quaternion.identity );
        // }
    }

    void Update () {
        // move side to side
        
    }

}
