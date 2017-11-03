using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinsroid : PulledObject {

    public float twinsSpeed;
    private Transform[] Twins;

    new void Start()
    {
        base.Start();
        Twins = new Transform[2];
        Twins[0] = transform.GetChild(0);
        Twins[1] = transform.GetChild(1);
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        RotateTwins();
    }

    public void RotateTwins()
    {
        foreach (Transform twin in Twins)
        {
            if (twin != null)
                twin.RotateAround(gameObject.transform.position, Vector3.forward, twinsSpeed * Time.deltaTime);
        }
    }
}
