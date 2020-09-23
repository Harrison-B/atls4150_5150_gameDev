using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    private float     xPos;
    public float      speed = .05f;
    public float      leftWall, rightWall;
    private Rigidbody2D rb;

    public GameObject Projectile;
    public Image healthbar;

    public KeyCode fireKey;

    public float health = 1f;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (xPos > leftWall) {
                xPos -= speed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall) {
                xPos += speed;
            }
        }

        if (Input.GetKeyDown(fireKey)) {
            Instantiate(Projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }

        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
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
}

