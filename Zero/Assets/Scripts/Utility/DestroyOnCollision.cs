﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {

    private PulledObject pulled_object;

    private void Awake()
    {
        pulled_object = gameObject.GetComponent<PulledObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //WARNING Asteroids are currently not destroyed when hitting a pickup. Good or Bad? :S
        if (!collision.gameObject.CompareTag("Pickup"))
            pulled_object.ReturnToPool();
    }
}
