using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;
    public int scoreValue;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        
        highScoreText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        highScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        //scoreValue += 5;
        scoreText.text = "Score:" + scoreValue.ToString();
        if(scoreValue > highScore)
        {
          
            highScore = scoreValue;
            highScoreText.text = "High Score:" + highScore.ToString();
        }
    }
}
