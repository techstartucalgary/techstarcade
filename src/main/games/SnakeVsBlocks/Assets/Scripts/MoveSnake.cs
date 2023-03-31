using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnake : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3[] prevPosition = new Vector3[3];
    float walkSpeed;
    float inputHorizontal;
    
    public Vector3[] PrevPosition {
        get {
            return prevPosition;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        walkSpeed = 5.0f;

        prevPosition[0] = new Vector3(0.0f, 0.0f, 0.0f);
        prevPosition[1] = new Vector3(0.0f, 0.0f, 0.0f);
        prevPosition[2] = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        prevPosition[0] = prevPosition[1];
        prevPosition[1] = prevPosition[2];
        prevPosition[2] = transform.position;

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
