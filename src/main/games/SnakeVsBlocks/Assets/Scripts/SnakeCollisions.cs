using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollisions : MonoBehaviour
{
    private int playerHealth = 1;
    int score = 0;
    public int numberOfChildren = 0;
    public bool inBlockCollision = false;
    public bool inSideCollision = false;
    int numberOfCollisions = 0;
    [SerializeField] GameObject snakeText;
    [SerializeField] GameObject snakeChild;
    GameObject myText;
    GameObject myChild;
    [SerializeField] GameObject GameOverScreen;

    float timeSinceCollision = 0;

    public int PlayerHealth {
        get {
            return playerHealth;
        }
        set {
            playerHealth = value;
        }
    }

    // public int ChildNumber {
    //     get {
    //         return childNumber;
    //     }
    // }
    
    // Start is called before the first frame update
    void Start()
    {
        myText = Instantiate(snakeText, transform.position, Quaternion.identity);
        myText.GetComponentInChildren<TextMesh>().text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update() 
    {
        myText.GetComponentInChildren<TextMesh>().text = playerHealth.ToString();
        myText.transform.position = transform.position;
        //Debug.Log(numberOfCollisions);

        if (inBlockCollision){
            timeSinceCollision += Time.deltaTime;
            //Debug.Log(timeSinceCollision);

            if (timeSinceCollision > 0.2f){
                playerHealth--;
                //GameObject block = collision.gameObject;
                //collision.gameObject.GetComponent<BlockCollision>().blockValue--;
                timeSinceCollision = 0;

            }
        }

        if (playerHealth <= 0){
            Time.timeScale = 0;
            GameOverScreen.GetComponent<GameOver>().Setup(score);
        }
        //myChild.transform.position = transform.position - new Vector3(0.0f, 0.4f, 0.0f);
        // if (inSideCollision){
        //     transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
        // }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Food(Clone)"){ //If ate food
            if (playerHealth == 1){ //If no child set yet
                numberOfChildren++;
                playerHealth += collision.gameObject.GetComponent<FoodCollision>().FoodValue;
                //Debug.Log(playerHealth);
                myChild = Instantiate(snakeChild, transform.position - new Vector3(0.0f, 0.4f, 0.0f), Quaternion.identity);
                myChild.transform.SetParent(transform);
            }
            else { //GO BACK TO UPDATING CHILDREN
                playerHealth += collision.gameObject.GetComponent<FoodCollision>().FoodValue;
                //Debug.Log(playerHealth);
            }
            myText.GetComponentInChildren<TextMesh>().text = playerHealth.ToString();
        }

        // if (collision.gameObject.name == "Blocks(Clone)"){ //If touches block
        //     inSideCollision = true;
        //     transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
        //     //transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
        //     //Debug.Log("YES");
        // }

    }

    // private void OnCollisionExit2D(Collision2D collision) {

    //     if (collision.gameObject.name == "Blocks(Clone)"){ //If touches block
    //         inSideCollision = false;
            
    //         //Debug.Log("YES");
    //     }

    // }

    private void OnTriggerEnter2D(Collider2D collision) {
        numberOfCollisions++;
        float yPosition = collision.gameObject.transform.position.y;
        //Debug.Log("ENTER");      
        //Debug.Log(transform.position.y);
        if(yPosition - transform.position.y > 0.97f){
            //Debug.Log("Huzzah");
            inBlockCollision = true;
        }
        playerHealth--;
        //GameObject block = collision.gameObject;
        //block.GetComponent<BlockCollision>().blockValue--;
        //Debug.Log(inBlockCollision);
    }

    // private void OnTriggerStay2D(Collider2D collision) {
    //     timeSinceCollision += Time.deltaTime;
    //     Debug.Log(timeSinceCollision);

    //     if (timeSinceCollision > 5.0f){
    //         playerHealth--;
    //         //GameObject block = collision.gameObject;
    //         collision.gameObject.GetComponent<BlockCollision>().blockValue--;
    //         timeSinceCollision = 0;

    //     }
    //     //Debug.Log(block.GetComponent<BlockCollision>().blockValue);
    // }

    // private void OnTriggerStay2D(Collider2D collision) {
    //     Debug.Log("HERE");
    // }
    private void OnTriggerExit2D(Collider2D collision) {
        //Debug.Log("EXIT");
        numberOfCollisions--;
        if (numberOfCollisions == 0){
            inBlockCollision = false;
        }
        //Debug.Log(inBlockCollision);

    }

    // private void OnCollisionExit2D(Collision2D collision) {
    //     if (collision.gameObject.name == "Blocks(Clone)"){ //If touches block
    //         //Time.timeScale = 1f;
    //         Debug.Log("EXIT");
    //     }
    // }
}
