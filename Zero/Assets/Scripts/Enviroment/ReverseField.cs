using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseField : MonoBehaviour {

    private Player playerScript;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.ChangeDirection();
        }
    }
}
