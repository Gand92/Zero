using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float rotationSpeed;
    public float radiusSpeed;

    private GameObject centerObject;
    private Vector3 desiredPosition;
    private int orbitNum;
    private float radius;

    void Start()
    {
        orbitNum = 1;
        radius = OrbitGrid.orbitDistance * orbitNum;
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
        transform.position = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
    }

    void Update()
    {
        //Modify this with a touch system
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            orbitNum++;
            radius = OrbitGrid.orbitDistance * orbitNum;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && orbitNum != 1)
        {
            orbitNum--;
            radius = OrbitGrid.orbitDistance * orbitNum;
        }
    }

    void FixedUpdate()
    {
        Move();
        ChangeOrbit(); //Change orbit if a key is pressed
    }

    public void Move()
    {
        //Creating an orbit around the black hole
        transform.RotateAround(centerObject.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public void ChangeOrbit()
    {
        //Smooth change of the radius of the orbit
        Vector3 desiredPosition = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
        float distance = Vector3.Distance(transform.position, desiredPosition);
        float percentage = distance / OrbitGrid.orbitDistance; //TODO try to not decrease this value to 0 or the velocity will be too low
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, radiusSpeed * percentage * Time.deltaTime); //velocity is reduced as much as the orbit is close to the new one
    }
}