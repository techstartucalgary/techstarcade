using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject canvas;

    
    public float rotTorque, acceleration, strafePower;

    private Rigidbody2D rigidBody;
    private Vector2 facingDirection;

    //private bool canStrafe = true;
    //private bool isStrafing;
    //private float strafeTime = 0.1f, strafeCooldown = 1f;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        facingDirection = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        Rotate();
        UpdateFaceDir();
        Move();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletClone = Instantiate(bullet, new Vector3(transform.position.x + facingDirection.x * 2, transform.position.y + facingDirection.y * 2, 0), transform.rotation);
            Bullet bulletScript = bulletClone.GetComponent<Bullet>();
            bulletScript.dir.x = facingDirection.x;
            bulletScript.dir.y = facingDirection.y;
        }
    }

    void Rotate()
    {
        //Clockwise Rotation
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidBody.AddTorque(-1 * rotTorque, ForceMode2D.Force);
        }

        //Counter Clockwise Rotation
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidBody.AddTorque(rotTorque, ForceMode2D.Force);
        }
    }

    void Move()
    {
        //Forward movement using the Up Arrow and W keys relative to the current rotation of the player
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
        {    
            rigidBody.AddRelativeForce(new Vector2(0, 1) * acceleration, ForceMode2D.Force);
        }
    }

    void UpdateFaceDir()
    {
        facingDirection.x = (float)Math.Cos((transform.rotation.eulerAngles.z + 90) * Math.PI / 180);
        facingDirection.y = (float)Math.Sin((transform.rotation.eulerAngles.z + 90) * Math.PI / 180);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid"){
            Destroy(gameObject);
            canvas.SetActive(!canvas.activeInHierarchy);
        }
    }

    //private IEnumerator Strafe(int lr)
    //{
    //    canStrafe = false;
    //    isStrafing = true;
    //    Vector2 originalVel = rigidBody.velocity;
    //    rigidBody.velocity = Vector2.zero;
    //    Vector2 v = originalVel;
    //    v.Normalize();
    //    Vector2 dir = Vector2.Perpendicular(v);
    //    Debug.Log(dir);
    //    rigidBody.velocity = dir * strafePower * lr;
    //    yield return new WaitForSeconds(strafeTime);
    //    isStrafing = false;
    //    yield return new WaitForSeconds(strafeCooldown);
    //    canStrafe = true;        
    //}
}
