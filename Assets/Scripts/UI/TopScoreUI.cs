using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopScoreUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI rankingUI;
   [SerializeField] private TextMeshProUGUI scoreUI;
   [SerializeField] private TextMeshProUGUI dateTimeUI;


    public void Init(
        int ranking, string score, string dateTime
        
        ) { 
        rankingUI.text = ranking.ToString();
        scoreUI.text = "SCORE: " + score;
        dateTimeUI.text = dateTime;
        Debug.Log("Đã hoàn thành");
        Debug.Log(scoreUI.text);
    }
}
