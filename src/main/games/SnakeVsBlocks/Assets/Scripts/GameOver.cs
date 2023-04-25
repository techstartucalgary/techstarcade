using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverScore;
    //GameObject scoreText;
    public void Setup(int scoreValue){
        gameObject.SetActive(true);
        GameOverScore.SetActive(true);
        GameOverScore.GetComponentInChildren<TextMesh>().text = "Score: " + scoreValue.ToString();
    }

    public void RestartButton(){
        Debug.Log("Restart Clicked");
        SceneManager.LoadScene("Game");
        //scoreText.text = "Score:" + score.ToString();
    }

    public void MainMenuButton(){
        Debug.Log("Main Menu Clicked");
        //scoreText.text = "Score:" + score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = Instantiate(GameOverScore, new Vector2(0f, 0.8f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
