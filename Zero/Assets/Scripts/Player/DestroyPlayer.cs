using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {

    public GameManager game_manager;
    private Player playerScript;

    private void Awake()
    {
        playerScript = gameObject.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* There is a little bug when the player fly very fast! If he hits an asteroid when shielded, sometimes even this trigger will shoot. *
         * So we need to check if the player is shielded or not in order to prevent his destruction when shielded.                            *
         * NB: we don't need to call again toggleShield() because it's already called in ShiedlCollisionHandler                               */
        if (!collision.gameObject.CompareTag("Pickup") && !playerScript.IsShielded())
        {
            game_manager.GameOver();
            Destroy(gameObject);
        }
    }
}
