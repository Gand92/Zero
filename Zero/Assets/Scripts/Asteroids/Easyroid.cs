using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easyroid : Asteroid {

    [MinMaxSlider(0f, 100f)]
    public Vector2 velocityRangeVector;
    [SerializeField]
    private int minVelocity, maxVelocity;

    private float timeBetweenChange;

    void Start()
    {
        minVelocity = (int) velocityRangeVector.x;
        maxVelocity = (int) velocityRangeVector.y;
        orbitNum = Random.Range(2, 6);
        rotationSpeed = Random.Range(minVelocity, maxVelocity);
        moveDirection = Random.Range(0, 2) * 2 - 1; //Randomly choosing clockwise or counterclockwise movement
        radius = OrbitGrid.orbitDistance * orbitNum;
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
        transform.position = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
        timeBetweenChange = Random.Range(3, 6);
    }

    void FixedUpdate()
    {
        Move();
        ChangeOrbit();
    }

    public override void Move()
    {
        //Creating an orbit around the black hole
        transform.RotateAround(centerObject.transform.position, Vector3.forward, moveDirection * rotationSpeed * Time.deltaTime);
    }

    public override void ChangeOrbit()
    {
        timeBetweenChange -= Time.deltaTime;
        if (timeBetweenChange <= 0f)
        {
            //Choosing new orbit
            int randomInt = (int)Random.Range(0, 2);
            if (randomInt == 0 && orbitNum > 1)
            {
                orbitNum--;
                radius = OrbitGrid.orbitDistance * orbitNum;
            }
            else
            {
                orbitNum++;
                radius = OrbitGrid.orbitDistance * orbitNum;
            }
            timeBetweenChange = Random.Range(3, 6);
        }
        //Smooth change of the radius of the orbit
        Vector3 desiredPosition = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
        float distance = Vector3.Distance(transform.position, desiredPosition);
        float percentage = distance / OrbitGrid.orbitDistance;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, radiusSpeed * percentage * Time.deltaTime); //velocity is reduced as much as the orbit is close to the new one
    }
}
