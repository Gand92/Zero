using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easyroid : Asteroid {

    void Start()
    {
        //orbitNum = Random.Range(2, 6);
        radius = OrbitGrid.orbitDistance * orbitNum;
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
        transform.position = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
    }

    void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        //Creating an orbit around the black hole
        transform.RotateAround(centerObject.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
