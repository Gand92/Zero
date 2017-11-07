using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollisionHandler : MonoBehaviour {

    private Player playerScript;

    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Pickup"))
            return;
        playerScript.toggleShield();
        Debug.Log("Shield on = " + playerScript.IsShielded());
        Destroy(gameObject);
    }
}
