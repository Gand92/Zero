using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectPickUp : PickUp {

    public int value;
    private GameScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameScoreManager>();
    }

    public override void ActivateEffect()
    {
        scoreManager.AddToScore(value);
    }
}
