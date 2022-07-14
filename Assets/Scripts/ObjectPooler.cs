using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i=0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.parent = gameObject.transform;
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.prefab.name, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
            return null;

        var objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
