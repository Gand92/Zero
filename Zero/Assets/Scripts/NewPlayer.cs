using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour {

    public float rotationSpeed;

    private GameObject centerObject;
    [SerializeField]
    private float radius = 0.5f;

    void Start()
    {
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
        transform.position = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
    }

    void Update()
    {
        //Modify this with a touch system
        if (Input.GetKey(KeyCode.UpArrow))
        {
            radius += 0.01f;
        }
        if (Input.GetKey(KeyCode.DownArrow) && radius > Time.deltaTime)
        {
            radius = Mathf.Clamp(radius - 0.01f, 0f, radius);
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
        transform.position = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position;
        //Vector3 desiredPosition = (transform.position - centerObject.transform.position).normalized * radius + centerObject.transform.position; transform.position = Vector3.MoveTowards(transform.position, desiredPosition, radius);
    }
}
