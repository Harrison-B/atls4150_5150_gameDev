using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    private float     xPos;
    public float      xspeed = .03f;
    private float     yPos = -4f;
    public float      yspeed = .03f;
    public float      leftWall, rightWall, topWall, bottomWall;
    private Rigidbody2D rb;
    public GameObject Projectile;
    public Image healthbar;
    public KeyCode fireKey;
    public float health = 1f;

    public List<GameObject> powerUps;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (xPos > leftWall) {
                xPos -= xspeed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall) {
                xPos += xspeed;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            if (yPos < topWall) {
                yPos += yspeed;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            if (yPos > bottomWall) {
                yPos -= yspeed;
            }
        }

        if (Input.GetKeyDown(fireKey)) {
            Instantiate(Projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }

        transform.localPosition = new Vector3(xPos, yPos, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemyprojectile")
        {
            Destroy(other.gameObject);
            health -= .1f;
            healthbar.fillAmount = health;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "powerup" && other.gameObject.GetComponent<PowerScript>().isFollowing == false)
        {
            Debug.Log("Powerup Hit");
            other.gameObject.GetComponent<PowerScript>().isFollowing = true;
            other.gameObject.GetComponent<PowerScript>().position = powerUps.Count + 1;

            if (powerUps.Count == 0) {
                other.gameObject.GetComponent<PowerScript>().followObject = GameObject.FindWithTag("Player");
            } else {
                other.gameObject.GetComponent<PowerScript>().followObject = powerUps[powerUps.Count - 1];
            }


            powerUps.Add(other.gameObject);
        }
    }
}

