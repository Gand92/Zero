﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {

    public GameManager game_manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Pickup"))
        {
            game_manager.GameOver();
            Destroy(gameObject);
        }
    }
}