using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefab = new List<GameObject>();
    [SerializeField][Range(0, 50)] int poolSize = 5;
    [SerializeField][Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int x = 0; x < enemyPrefab.Count; x++)
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = Instantiate(enemyPrefab[i], transform);
                pool[i].SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void EnabledObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnabledObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
