
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{   
    //TODO
        // display game over text
        
    private Rigidbody2D playerController = FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>();
    private bool isGameOver = false;
    private float restartDelay = 0.5f;
    public void GameOver() {
        if(!isGameOver) {
            isGameOver = true;
            Debug.Log("Hit something, Game over from the Game state"); 
            playerController.freezeRotation = false;
            Time.timeScale = 0.5f;
            Invoke("Restart", restartDelay);
        }        
    }

    void Restart() {
        Time.timeScale = 1;
        FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>().freezeRotation = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
