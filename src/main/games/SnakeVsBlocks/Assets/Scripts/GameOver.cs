using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //[SerializeField] TextMesh scoreText;
    public void Setup(int score){
        gameObject.SetActive(true);
        //scoreText.text = "Score:" + score.ToString();
    }

    public void RestartButton(){
        Debug.Log("Restart Clicked");
        //scoreText.text = "Score:" + score.ToString();
    }

    public void MainMenuButton(){
        Debug.Log("Main Menu Clicked");
        //scoreText.text = "Score:" + score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
