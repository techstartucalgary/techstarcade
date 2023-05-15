using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverScore;
    public void Setup(int scoreValue){
        gameObject.SetActive(true);
        GameOverScore.SetActive(true);
        GameOverScore.GetComponentInChildren<TextMesh>().text = "Score: " + scoreValue.ToString();
    }

    public void RestartButton(){
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
