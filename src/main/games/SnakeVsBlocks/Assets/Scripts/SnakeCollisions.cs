using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollisions : MonoBehaviour
{
    private int playerHealth = 1;
    [SerializeField] GameObject score;
    GameObject scoreText;
    public int scoreValue = 0;
    public int numberOfChildren = 0;
    public bool inBlockCollision = false;
    public bool inSideCollision = false;
    int numberOfCollisions = 0;
    [SerializeField] GameObject snakeText;
    [SerializeField] GameObject snakeChild;
    GameObject myText;
    GameObject myChild;
    [SerializeField] GameObject GameOverScreen;

    public float startTime = 0;

    float timeSinceCollision = 0;

    int updateSpeed = 0;

    public int PlayerHealth {
        get {
            return playerHealth;
        }
        set {
            playerHealth = value;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        myText = Instantiate(snakeText, transform.position, Quaternion.identity);
        myText.GetComponentInChildren<TextMesh>().text = playerHealth.ToString();
        scoreText = Instantiate(score, new Vector2(2.4f, 4.8f), Quaternion.identity);
        scoreText.GetComponentInChildren<TextMesh>().text = "Score: " + scoreValue.ToString();
        Time.timeScale = 2;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update() 
    {
        myText.GetComponentInChildren<TextMesh>().text = playerHealth.ToString();
        myText.transform.position = transform.position;
        if (updateSpeed >= 50 && Time.timeScale < 10.0f){
            updateSpeed = 0;
            Time.timeScale += 0.5f;
        }

        if (inBlockCollision){
            timeSinceCollision += Time.deltaTime;

            if (timeSinceCollision > (0.4f + (0.05f * (Time.timeScale - 2.0f)))){ //CHANGE
                playerHealth--;
                timeSinceCollision = 0;
            }
        }

        if (playerHealth <= 0){
            Time.timeScale = 0;
            GameOverScreen.GetComponent<GameOver>().Setup(scoreValue);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Food(Clone)"){ //If ate food
            if (playerHealth == 1){ //If no child set yet
                numberOfChildren++;
                playerHealth += collision.gameObject.GetComponent<FoodCollision>().FoodValue;
                scoreValue += 10*collision.gameObject.GetComponent<FoodCollision>().FoodValue;
                updateSpeed += collision.gameObject.GetComponent<FoodCollision>().FoodValue;
                scoreText.GetComponentInChildren<TextMesh>().text = "Score: " + scoreValue.ToString();
                myChild = Instantiate(snakeChild, transform.position - new Vector3(0.0f, 0.4f, 0.0f), Quaternion.identity);
                myChild.transform.SetParent(transform);
            }
            else { //GO BACK TO UPDATING CHILDREN
                playerHealth += collision.gameObject.GetComponent<FoodCollision>().FoodValue;
                scoreValue += 10*collision.gameObject.GetComponent<FoodCollision>().FoodValue;
                updateSpeed += collision.gameObject.GetComponent<FoodCollision>().FoodValue;
                scoreText.GetComponentInChildren<TextMesh>().text = "Score: " + scoreValue.ToString();
            }
            myText.GetComponentInChildren<TextMesh>().text = playerHealth.ToString();
        }

    }



    private void OnTriggerEnter2D(Collider2D collision) {
        numberOfCollisions++;
        float yPosition = collision.gameObject.transform.position.y;

        if(yPosition - transform.position.y > 0.97f){
            inBlockCollision = true;
        }
        playerHealth--;
    }


    private void OnTriggerExit2D(Collider2D collision) {
        numberOfCollisions--;
        if (numberOfCollisions == 0){
            inBlockCollision = false;
        }

    }

}
