using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;

    // private float pillarSpeed;
    private float jumpForce;
    private float moveVertical;
    void OnCollisionEnter2D(Collision2D collision) => Log(collision);
    void OnCollisionStay2D(Collision2D collision) => Log(collision);

    void Log(Collision2D collision)
    {
        Debug.Log($"Called on {name} because a collision with {collision.collider.name}");
    }

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();

        // pillarSpeed = 2;
        jumpForce = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (moveVertical > 0.1f) {  // add a down movements for downward boosts
            player.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }
}
