using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectPickUp : PickUp {

    public int value;
    private GameScoreManager scoreManager;
    //private PulledObject pulled_object;

    private void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameScoreManager>();
        //pulled_object = gameObject.GetComponent<PulledObject>();
    }

    public override void ActivateEffect()
    {
        scoreManager.AddToScore(value);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        ActivateEffect();
    //        ReturnToPool();
    //    }
    //    else if (collision.gameObject.CompareTag("BlackHole"))
    //    {
    //        ReturnToPool();
    //    }
    //}
}
