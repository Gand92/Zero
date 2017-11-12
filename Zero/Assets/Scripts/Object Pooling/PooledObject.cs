using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour {

    [System.NonSerialized]
    ObjectPool poolInstanceForPrefab;

    public ObjectPool Pool { get; set; }

    public void ReturnToPool()
    {
        if (Pool)
        {
            Pool.AddObject(this);
        } else
        {
            Destroy(gameObject);
        }
    }

    public T GetPooledInstance<T>(Vector3 position) where T : PooledObject
    {
        if (!poolInstanceForPrefab)
        {
            poolInstanceForPrefab = ObjectPool.GetPool(this);
        }
        return (T)poolInstanceForPrefab.GetObject(position);
    }
}
