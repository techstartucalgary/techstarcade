using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    GameObject snakeHead;
    Rigidbody2D rb;
    [SerializeField] GameObject blockText;
    GameObject myText;
    public int blockValue;
    private bool myCollision = false;

    int snakeHealth;
    
    // public int BlockValue {
    //     get {
    //         return blockValue;
    //     }
    // }
    // Start is called before the first frame update
    void Start()
    {
        snakeHead = GameObject.Find("SnakeHead");
        rb = gameObject.GetComponent<Rigidbody2D>();
        myText = Instantiate(blockText, transform.position, Quaternion.identity);
        blockValue = (int)UnityEngine.Random.Range(1.1f, 5.9f);
        myText.GetComponentInChildren<TextMesh>().text = blockValue.ToString();
        snakeHealth = snakeHead.GetComponent<SnakeCollisions>().PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(blockValue);
        if (blockValue == 0){
            Destroy(myText);
            Destroy(gameObject);
        }
        myText.GetComponentInChildren<TextMesh>().text = blockValue.ToString();
        if (snakeHead.GetComponent<SnakeCollisions>().inBlockCollision == true){
            if (myCollision && snakeHead.GetComponent<SnakeCollisions>().PlayerHealth != snakeHealth) {
                blockValue--;
            }
            rb.Sleep();
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else {
            // Debug.Log(myCollision);
            rb.WakeUp();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        snakeHealth = snakeHead.GetComponent<SnakeCollisions>().PlayerHealth;
        myText.transform.position = transform.position;

        if (transform.position.y < -6.0f){
            Destroy(myText);
            Destroy(gameObject);
        }
        //Debug.Log(rb.IsAwake());
    }
    
    // private void OnTriggerEnter2D(Collider2D collision) {
    //     rb.Sleep();
    //     Debug.Log("Sleeping");

    // }

    private void OnTriggerEnter2D(Collider2D other) {
       // if(other.gameObject.name != "SnakeHead"){
            //Debug.Log("ENTERING");
            myCollision = true;
            //rb.Sleep();
       // }
    }
    private void OnTriggerExit2D(Collider2D other) {
        //if(other.gameObject.name != "SnakeHead"){
            // Debug.Log("Awake");
            //Debug.Log("Awake Now 2");
            myCollision = false;
            //rb.WakeUp();
        //}
    }
}
