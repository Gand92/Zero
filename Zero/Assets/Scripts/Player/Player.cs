using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Velocity Info")]
    public float rotationSpeed;
    public float radiusSpeed;
    [Header("Fuel Info")]
    public Image fuel_image;
    public float fuelSpeedConsumption;
    public float fuelSpeedRecharge;

    private GameObject centerObject;
    private Vector3 desiredPosition;
    private int orbitNum;
    private float radius;
    private bool hasShield;
    private FuelHandler fuelHandler;
    private float count;

    void Awake()
    {
        count = 0;
        hasShield = false;
        orbitNum = 1;
        radius = OrbitGrid.orbitDistance * orbitNum;
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
        transform.position = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
        fuelHandler = fuel_image.GetComponent<FuelHandler>();
    }

    void Update()
    {
        //Modify this with a touch system
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ModifyRadius(1);
        if (Input.GetKeyDown(KeyCode.DownArrow) && orbitNum != 1)
            ModifyRadius(-1);
        if (Input.GetKey(KeyCode.Space))
        {
            if (count == 0)
            {
                ModifySpeed(1);
                count += 1;
            }
            fuelHandler.ConsumeFuel(fuelSpeedConsumption * Time.deltaTime);
            if (fuelHandler.GetCurrentFuel() == 0 && count == 1)
            {
                ModifySpeed(-1);
                count -= 1;
            }
        } else {
            if (count == 1)
            {
                ModifySpeed(-1);
                count -= 1;
            }
            fuelHandler.RestoreFuel(fuelSpeedRecharge * Time.deltaTime); //We have another update in Turbo Handler with the same line, this one has to be removed on release on smartphone
        }
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

    //Used for turbo
    public void ModifySpeed(int num)
    {
        if (num == 1)
        {
            rotationSpeed += 40f;
            radiusSpeed += 2.5f;
        }
        if (num == -1)
        {
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

    public float GetFuelSpeedConsumption()
    {
        return fuelSpeedConsumption;
    }

    public float GetFuelSpeedRecharge()
    {
        return fuelSpeedRecharge;
    }

}