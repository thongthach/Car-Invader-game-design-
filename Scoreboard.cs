using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Scoreboard : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    TMP_Text scoreText;

    public void Score(int scorePerHit)
    {
       score += scorePerHit;
       scoreText.text = score.ToString();
    }

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
       

    }
   

    // Update is called once per frame
    
}
