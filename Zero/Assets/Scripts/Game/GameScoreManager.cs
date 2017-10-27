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
        SetScoreCounter(0);
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 1)
        {
            score += (int)timePassed;
            SetScoreCounter(score);
            timePassed -= (int)timePassed;
        }
    }

    private void SetScoreCounter(int score)
    {
        scoreText.text = score.ToString();
    }

}
