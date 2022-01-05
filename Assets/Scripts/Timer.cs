using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    GameManager gm;
    public Text scoreText;
    GameObject increaseScoreText;

    // set it to true when gameplay has started, to false when level finished or game paused
    private bool timerRunning = false;
    public void SetTimerRunning(bool value) { timerRunning = value; }

    private float remainingTime = 5F;
    private float scoreTimer = 0F;
    public int score = 0;

    PythonStarter python;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        increaseScoreText = GameObject.Find("UI_ScorePlus");
        python = GameObject.Find("GameManager").GetComponent<PythonStarter>();
    }

    private void Update()
    {
        if (timerRunning)
        {
            remainingTime -= Time.deltaTime;
            scoreTimer += Time.deltaTime;

            if (scoreTimer >= 0.1F)
            {
                score += 1;
                scoreTimer = 0F;
                scoreText.text = "Score: " + score.ToString();
            }
            
        }
        if (remainingTime <= 0F)
        {
            Highscore.SetHighscore(score);
            gm.LoadMenu();
            python.quitCMD();
        }
    }

    public void ReduceScore(int value)
    {
        score = score - value;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int value)
    {
        score = score + value;
        scoreText.text = "Score: " + score.ToString();
        //increaseScoreText.text = "+ " + value;
    }
}
