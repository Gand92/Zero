using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Asteroid : MonoBehaviour {

    [SerializeField]
    protected float rotationSpeed;     //TODO enemy rotationSpeed need to be randomly chosen
    protected float moveDirection;
    protected GameObject centerObject;
    protected int orbitNum;
    protected float radius;
    protected float radiusSpeed = 0.8f;

    public abstract void Move();
    public abstract void ChangeOrbit();

}
