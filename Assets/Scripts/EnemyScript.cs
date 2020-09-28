using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyProjectile;

    public float yspeed = 0.005f;

    public float amplitude = 0.5f;
    public float speed = 2f;
    public float      leftWall, rightWall;

    // Start is called before the first frame update
    void Start()
    {
        float delay = Random.Range(2f, 10f);
        float rate = Random.Range(2f, 8f);
        InvokeRepeating("Fire", delay, rate);
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude / 2;
        transform.position = new Vector2(transform.position.x - offset, transform.position.y - yspeed);

        if (transform.position.x > rightWall) {
            transform.position = new Vector2(rightWall, transform.position.y);
        }

        if (transform.position.x < leftWall) {
            transform.position = new Vector2(leftWall, transform.position.y);
        }
    }

    private void Fire() {
        int i = Random.Range(0,100);
        if (i>20) {
            Instantiate(enemyProjectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity );
        }
    }
}
