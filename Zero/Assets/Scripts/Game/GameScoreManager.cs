using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreManager : MonoBehaviour {

    public Text scoreText;

    private int score;
    private float timePassed;

    private void Start()
    {
        scoreText.text = "0";
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 1)
        {
            //score += (int)timePassed;
            //SetScoreCounter(score);
            AddToScore((int)timePassed);
            timePassed -= (int)timePassed;
        }
    }

    public void AddToScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

}
