using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnake : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3[] prevPosition = new Vector3[3];
    float walkSpeed;
    float inputHorizontal;

    float timeSc = 0;
    
    public Vector3[] PrevPosition {
        get {
            return prevPosition;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        walkSpeed = 10.0f;
        timeSc = Time.timeScale;
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
        walkSpeed += (Time.timeScale - timeSc) * 2.0f;
        timeSc = Time.timeScale;
        
        if(inputHorizontal != 0){
            rb.AddForce(new Vector2(inputHorizontal * walkSpeed, 0f));
        }
    }
}
