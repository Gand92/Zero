using System;
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
    private bool isAccelerating;
    private bool hasShield;

    void Start()
    {
        isAccelerating = false;
        hasShield = false;
        orbitNum = 1;
        radius = OrbitGrid.orbitDistance * orbitNum;
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
        transform.position = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
    }

    void Update()
    {
        //Modify this with a touch system
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ModifyRadius(1);
        if (Input.GetKeyDown(KeyCode.DownArrow) && orbitNum != 1)
            ModifyRadius(-1);
        if (Input.GetKeyDown(KeyCode.Space))
            ModifySpeed(1);
        if (Input.GetKeyUp(KeyCode.Space))
            ModifySpeed(-1);
    }

    void FixedUpdate()
    {
        Move();
        ChangeOrbit();
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
        float percentage = distance / OrbitGrid.orbitDistance + 0.25f; //+0,25 to avoid percentage = 0
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, radiusSpeed * percentage * Time.deltaTime); //velocity is reduced as much as the orbit is close to the new one
    }

    public void ModifyRadius(int num)
    {
        if (num == 1)
            orbitNum++;
        if (num == -1 && orbitNum > 1)
            orbitNum--;
        radius = OrbitGrid.orbitDistance * orbitNum;
    }

    public void ModifySpeed(int num)
    {
        if (num == 1)
        {
            isAccelerating = true;
            rotationSpeed += 40f;
            radiusSpeed += 2.5f;
        }
        if (num == -1)
        {
            isAccelerating = false;
            rotationSpeed -= 40f;
            radiusSpeed -= 2.5f;
        }
    }

    public bool IsShielded()
    {
        return hasShield;
    }

    public void toggleShield()
    {
        hasShield = !hasShield;
    }

}