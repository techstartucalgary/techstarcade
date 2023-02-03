using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] GameObject LevelManager;

    void Awake()
    {
        LevelManager Lv = LevelManager.GetComponent<LevelManager>();
        GetComponent<TextMeshProUGUI>().text = $"Score: {Lv.score}";
    }
}
