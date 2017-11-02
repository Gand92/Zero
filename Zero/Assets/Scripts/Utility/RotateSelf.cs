using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {

    public float rotationSpeed;

	void Update () {
        //Rotate around itself
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * rotationSpeed);
    }
}
