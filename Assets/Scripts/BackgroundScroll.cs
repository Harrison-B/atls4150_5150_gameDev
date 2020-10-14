using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public List<GameObject> backgrounds;
    private Camera mainCamera;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        loadBackground();
    }

    void loadBackground() {



        // GameObject clone = Instantiate(background) as GameObject;
        // float backgroundHeight = background.GetComponent<SpriteRenderer>().bounds.size.y;
        // for(int i = 0; i <= 3; i++) {
        //     GameObject c = Instantiate(clone) as GameObject;
        //     c.transform.SetParent(background.transform);
        //     c.transform.position = new Vector2 (background.transform.position.x, -backgroundHeight * i);
        // }
        // Destroy(clone);
        // Destroy(background.GetComponent<SpriteRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        repositionBackground();
    }

    void repositionBackground() {
        
        if (!GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManagerScript>().isGameOver) {
            foreach (GameObject obj in backgrounds) {
                obj.transform.position = new Vector2 (obj.transform.position.x, obj.transform.position.y - 0.0025f);
            }

            if (backgrounds[backgrounds.Count - 1].transform.position.y < 1) {
                GameObject firstChild = backgrounds[0].gameObject;
                GameObject lastChild = backgrounds[1].gameObject;
                float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y;

                firstChild.transform.position = new Vector2(lastChild.transform.position.x, lastChild.transform.position.y - 0.05f + halfObjectWidth * 2);

                backgrounds[0] = lastChild;
                backgrounds[1] = firstChild;
            }
        }



        // Transform[] children = background.GetComponentsInChildren<Transform>();
        // if(children.Length > 1) {
        //     GameObject firstChild = children[1].gameObject;
        //     GameObject lastChild = children[children.Length - 1].gameObject;
        //     float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y;

        //     foreach (Transform obj in children) {
        //         obj.position.y = obj.position.y - 0.05f;
        //     }

        //     if (transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectWidth) {
        //         firstChild.transform.SetAsLastSibling();
        //         firstChild.transform.position = new Vector2(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectWidth * 2);
        //     }
        // }
    }

}
