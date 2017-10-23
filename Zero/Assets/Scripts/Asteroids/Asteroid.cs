using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [MinMaxSlider(0f, 100f)]
    public Vector2 velocityRangeVector;
    [SerializeField]
    protected int minVelocity, maxVelocity;
    protected float rotationSpeed;
    protected float moveDirection;
    protected GameObject centerObject;
    protected int orbitNum;
    protected float radius;
    protected float radiusSpeed = 0.8f;
    protected float timeBetweenChange;

    public void Start()
    {
        minVelocity = (int)velocityRangeVector.x;
        maxVelocity = (int)velocityRangeVector.y;
        //Choosing a random orbit
        //orbitNum = Random.Range(5, 10);
        orbitNum = 10;
        //Choosing a random angular velocity
        rotationSpeed = Random.Range(minVelocity, maxVelocity);
        //Randomly choosing clockwise or counterclockwise movement
        moveDirection = Random.Range(0, 2) * 2 - 1; 
        radius = OrbitGrid.orbitDistance * orbitNum;
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
        //Choosing a starting position, it could be randomize or with SpawnPoints NOW CONTROLLED BY ASTEROIDSPAWNER
        //transform.position = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
        //timeBetweenChange = Random.Range(3, 6);
        timeBetweenChange = 3.0f;
    }

    public void FixedUpdate()
    {
        Move();
        ChangeOrbit();
    }

    public void Move()
    {
        //Creating an orbit around the black hole
        transform.RotateAround(centerObject.transform.position, Vector3.forward, moveDirection * rotationSpeed * Time.deltaTime);
    }

    public void ChangeOrbit()
    {
        //timeBetweenChange -= Time.deltaTime;
        //if (timeBetweenChange <= 0f)
        //{
        //    //Choosing new orbit
        //    int randomInt = (int)Random.Range(0, 2);
        //    if (randomInt == 0 && orbitNum > 1)
        //    {
        //        orbitNum--;
        //        radius = OrbitGrid.orbitDistance * orbitNum;
        //    }
        //    else
        //    {
        //        orbitNum++;
        //        radius = OrbitGrid.orbitDistance * orbitNum;
        //    }
        //    timeBetweenChange = Random.Range(3, 6);
        //}
        timeBetweenChange -= Time.deltaTime;
        if (timeBetweenChange <= 0)
        {
            orbitNum--;
            radius = OrbitGrid.orbitDistance * orbitNum;
            timeBetweenChange = 3.0f;
        }
        //Smooth change of the radius of the orbit
        Vector3 desiredPosition = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
        float distance = Vector3.Distance(transform.position, desiredPosition);
        float percentage = distance / OrbitGrid.orbitDistance  + 0.25f;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, radiusSpeed * percentage * Time.deltaTime); //velocity is reduced as much as the orbit is close to the new one
    }

}
