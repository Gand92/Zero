using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : PickUp
{

    public GameObject shield;
    private GameObject player;
    private Player playerScript;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    public override void ActivateEffect()
    {
        if (!playerScript.IsShielded())
        {
            playerScript.toggleShield();
            Debug.Log("Shield on = " + playerScript.IsShielded());
            Instantiate(shield, player.transform);
        }
    }
}
