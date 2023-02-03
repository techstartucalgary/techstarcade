using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength; 
    // Start is called before the first frame update
    // runs as soon as the code is enabled and runs once
    void Start()
    {
        
    }

    // Update is called once per frame
    // runs constantly while script is enabled and will fire off every line of code every single frame over and over
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        // vector2.up is a built in shortcup for (0,1)
    }
}
