using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBehaviour : MonoBehaviour
{
    GameObject snakeHead;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        snakeHead = GameObject.Find("SnakeHead");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (snakeHead.GetComponent<SnakeCollisions>().inBlockCollision == true){
            rb.Sleep();
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else {
            rb.WakeUp();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if (transform.position.y < -6.0f){
            Destroy(gameObject);
        }   
    }
}
