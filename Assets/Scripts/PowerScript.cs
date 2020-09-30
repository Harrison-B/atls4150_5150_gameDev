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

    public GameObject followObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isFollowing) {
            transform.position = new Vector2(transform.position.x, transform.position.y - yspeed);
        } else {
            ypos = position * 0.3f;
            distance = Vector2.Distance(followObject.transform.position, transform.position);
            if (distance > 0.4f) {
                transform.position = Vector2.MoveTowards(transform.position, followObject.transform.position, followSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && isFollowing == false){
            Debug.Log("we hit the player");
            transform.position = new Vector2(other.transform.position.x, other.transform.position.y - ypos);
        }

        if (other.gameObject.tag =="wall") {
            Destroy(this.gameObject);
        }
    }
}
