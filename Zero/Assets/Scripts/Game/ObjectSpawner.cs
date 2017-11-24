using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public PooledObject[] pooledList = new PooledObject[2];
    public int spawnOrbit = 14;
    public float timeBetweenSpawn;

    private GameObject centerObject;
    private float radius;
    private Vector3 desiredPosition;

	void Start () {
        radius = OrbitGrid.orbitDistance * spawnOrbit;
        centerObject = GameObject.FindGameObjectWithTag("BlackHole");
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            PooledObject prefab = pooledList[Random.Range(0, pooledList.Length)];
            PooledObject objectSpawned;
            if (prefab.CompareTag("Field"))
            {
                radius = OrbitGrid.orbitDistance * Random.Range(1, spawnOrbit);
            }
            desiredPosition = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0)).normalized * radius + centerObject.transform.position;
            if (prefab)
            {
                objectSpawned = prefab.GetPooledInstance<PooledObject>();
                objectSpawned.transform.position = desiredPosition;
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

}
