using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Search;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    [System.Serializable]
    public class pool
    {
        public string tag;
        public GameObject enemyPrefab;
        public int poolSize;
    }

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<pool> pools;

    #region *****Singleton*****
    public static ObjectPools Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    LevelManager levelManager;

    private void Start()
    {
        CreatingPool();

    }

    private void CreatingPool()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.enemyPrefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
