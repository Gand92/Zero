using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public float timeBetweenSpawn;
    public GameObject[] asteroidPrefabList = new GameObject[2];

    private GameObject centerObject;
    private int spawnOrbit = 10;
    private float radius;
    private Vector3 desiredPosition;

	// Use this for initialization
	void Start () {
        radius = OrbitGrid.orbitDistance * spawnOrbit;
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
    }
	
	// Update is called once per frame
	void Update () {
        timeBetweenSpawn -= Time.deltaTime;
        if (timeBetweenSpawn <= 0)
        {
            desiredPosition = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0)).normalized * radius + centerObject.transform.position;
            Instantiate(asteroidPrefabList[Random.Range(0, asteroidPrefabList.Length)], desiredPosition, Quaternion.identity);
            timeBetweenSpawn = 1.0f;
        }
	}
}
