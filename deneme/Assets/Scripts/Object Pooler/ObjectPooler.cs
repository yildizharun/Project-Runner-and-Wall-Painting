using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    Dictionary<string, List<Pool>> poolDictionary;

    public List<Pool> pools;

    public  static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
        fillPools();
    }
    
    public void fillPools()
    {
        foreach(Pool pool in pools)
        {
            for(int i = 0; i < pool.size; i++)
            {
                GameObject objectToFill = Instantiate(pool.objectType);
                objectToFill.SetActive(false);
                pool.objectPool.Add(objectToFill);
            }
        }
    }
    public GameObject spawnObjectFromPool(string tag,Vector3 position,Quaternion rotation)
    {
        GameObject objectToSpawn = null;
        foreach (Pool pool in pools)
        {
            if (pool.tag == tag)
            {
                foreach(GameObject objectInPool in pool.objectPool)
                {
                    try
                    {
                        if (!objectInPool.activeSelf)
                        {
                            objectInPool.SetActive(true);
                            objectInPool.transform.position = position;
                            objectInPool.transform.rotation = rotation;
                            objectToSpawn = objectInPool;
                            return objectToSpawn;
                        }
                    }
                    catch
                    {
                        Debug.Log("Object may be deleted!");
                    }
                }
                objectToSpawn = Instantiate(pool.objectType, position, rotation);
            }
        }
        return objectToSpawn;
    }
}
