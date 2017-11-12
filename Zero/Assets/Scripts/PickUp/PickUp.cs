using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : PooledObject {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActivateEffect();
            ReturnToPool();
        }
        else if (collision.gameObject.CompareTag("BlackHole"))
        {
            ReturnToPool();
        }
    }

    public abstract void ActivateEffect();
}
