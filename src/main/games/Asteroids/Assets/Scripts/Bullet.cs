using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity;
    public Vector2 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the bullet in the direction the ship was facing, destroys it if it passes the position thresholds
        transform.Translate(new Vector3(velocity * dir.x, velocity * dir.y, 0), Space.World);
        if (transform.position.x > 30 || transform.position.x < -30){Destroy(gameObject);}
        if (transform.position.y > 30 || transform.position.y < -30){Destroy(gameObject);}
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
