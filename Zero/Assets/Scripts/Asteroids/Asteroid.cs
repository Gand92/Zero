using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [Header("Asteroid Velocity")]
    public float radiusSpeed;
    public float rotationSpeed;
    [Space(3)]
    protected GameObject centerObject;

    //Variables used for lerping object's size
    private Vector3 initialScale;
    private Vector3 finalScale;
    private float progress = 0;
    private float timeScale = 1.0f;


    public void Start()
    {
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");

        initialScale = transform.localScale;
        finalScale = new Vector3(0,0,0);
    }

    public void FixedUpdate()
    {
        Move();
        ChangeSize();
    }

    public void Move()
    {
        //Creating an orbit around the black hole
        transform.RotateAround(centerObject.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        ChangeOrbit();
    }

    public void ChangeOrbit()
    {
        //Movement towards the blackhole
        transform.position = Vector3.MoveTowards(transform.position, centerObject.transform.position, radiusSpeed * Time.deltaTime);
    }

    public void ChangeSize()
    {
        float distance = Vector3.Distance(transform.position, centerObject.transform.position);
        if (distance <= 2f && progress <= 1) {
            transform.localScale = Vector3.Lerp(initialScale, finalScale, progress);
            progress += Time.deltaTime * timeScale;
        }
    }

}
