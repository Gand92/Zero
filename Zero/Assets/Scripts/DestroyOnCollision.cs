using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.transform.parent != null && gameObject.transform.parent.tag == "Twinsroid")
        {
            Destroy(gameObject.transform.parent.gameObject); //Destroy Twinsroid and Twins
            return;
        }
        Destroy(gameObject);
    }
}
