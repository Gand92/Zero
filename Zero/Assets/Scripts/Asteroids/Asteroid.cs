using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Asteroid : MonoBehaviour {

    protected float rotationSpeed;     //TODO enemy rotationSpeed need to be randomly chosen
    protected GameObject centerObject;
    protected int orbitNum;
    protected float radius;

    public abstract void Move();

    public void SetOrbitNum(int value)
    {
        orbitNum = value;
    }

}
