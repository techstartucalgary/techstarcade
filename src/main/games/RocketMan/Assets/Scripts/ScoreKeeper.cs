using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public float playerScore;
    public PlayerController playerController;
    public void scoreChange() {
        playerScore++;
    }
}
