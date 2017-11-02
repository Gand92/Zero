using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public int orbitNumber;
    private LineRenderer lr;
    private float radCircle;

    void Start()
    {
        radCircle = OrbitGrid.orbitDistance * orbitNumber;
        lr = gameObject.GetComponent<LineRenderer>();
        DrawCircle(lr);
    }

    void DrawCircle(LineRenderer lr)
    {
        int i = 0;
        for (float theta = 0f; theta < 2 * Mathf.PI; theta += 0.0174533f)
        {
            float x = radCircle * Mathf.Cos(theta);
            float y = radCircle * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, y, 1);
            lr.SetPosition(i, pos);
            i++;
        }
    }
}
