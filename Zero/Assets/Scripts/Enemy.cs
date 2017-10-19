using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float rotationSpeed;     //TODO enemy rotationSpeed need to be randomly chosen

    private GameObject target;
    private Vector3 desiredPosition;
    private float distance;
    private int orbitNum;
    private float radius;

    void Start()
    {
        orbitNum = Random.Range(2, 6);
        radius = OrbitGrid.orbitDistance * orbitNum;
        target = GameObject.FindGameObjectWithTag("BlackHole");
        transform.position = (transform.position - target.transform.position).normalized * radius + target.transform.position;
    }

    void FixedUpdate()
    {
        //Creating an orbit around the black hole
        transform.RotateAround(target.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
