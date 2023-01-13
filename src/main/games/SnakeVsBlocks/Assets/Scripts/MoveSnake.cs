using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnake : MonoBehaviour
{
    Rigidbody2D rb;

    float walkSpeed;
    float inputHorizontal;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        walkSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");   
        
        //rb.setForce(new Vector2(0f, 0f));
        //rb.Sleep();
        //print(inputHorizontal);
        if(inputHorizontal != 0){
            rb.AddForce(new Vector2(inputHorizontal * walkSpeed, 0f));
            //inputHorizontal = 0;
            //rb.MovePosition(new Vector2(5, 0f));
            //inputHorizontal = 0;
            //transform.position = new Vector3(1,0,0);
        }
    }
}
