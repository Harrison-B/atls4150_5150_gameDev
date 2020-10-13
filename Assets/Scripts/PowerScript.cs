using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public float yspeed = 0.005f;

    public float followSpeed = 0.05f;

    public bool isFollowing = false;

    public float position = 1f;
    private float ypos;

    private float distance;
    
    public int powerUpType;
    public float distanceFromPlayer = 1f;

    public float distanceFromPowerup = 0.4f;

    public GameObject followObject, player, explosion, projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFollowing) {
            transform.position = new Vector2(transform.position.x, transform.position.y - yspeed);
        } else if (followObject) { // Adding this check makes it so if the last one is deleted, it doesn't throw an error
            ypos = position * 0.3f;
            distance = Vector2.Distance(followObject.transform.position, transform.position); 
            if ((distance > distanceFromPowerup && followObject != player) || (distance > distanceFromPlayer && followObject == player)) {
                transform.position = Vector2.MoveTowards(transform.position, followObject.transform.position, followSpeed);
            }

            if (powerUpType == 1) {
                int i = Random.Range(0,600);
                if (i >= 599) {
                    // Debug.Log(i);
                    Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity );
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && isFollowing == false){
            //Debug.Log("we hit the player");
            //transform.position = new Vector2(other.transform.position.x, other.transform.position.y - ypos);
        }

        if (!isFollowing && other.gameObject.tag =="wall") {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemyprojectile") {
            Debug.Log("Apple and projectile hit");

            GameObject powerupExplosion = Instantiate (explosion, transform.position, transform.rotation, explosion.transform.parent);

            powerupExplosion.transform.localScale = new Vector2(-0.5f, -0.5f);

            if (isFollowing) {
                int tempnum = player.GetComponent<PlayerScript>().powerUps.Count - 1;
                for (int n = tempnum; n + 2 > position; n-- ) {
                    Debug.Log("   Deleting # " + n);
                    GameObject temp = player.GetComponent<PlayerScript>().powerUps[n];
                    player.GetComponent<PlayerScript>().powerUps.Remove(temp);

                    if (temp.name == "Pineapple(Clone)") {
                            player.GetComponent<PlayerScript>().pineappleCount--;
                    }

                    Destroy(temp.gameObject);
                }
            }
        }
    }
}
