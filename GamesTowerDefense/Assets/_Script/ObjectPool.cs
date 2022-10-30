using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Variable for object loop and the timer for it
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] int _poolSize = 5;
    [SerializeField] float _spawnTimer = 1f;

    GameObject[] m_pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        m_pool = new GameObject[_poolSize];

        for (int i = 0; i < m_pool.Length; i++)
        {
            m_pool[i] = Instantiate(_enemyPrefab, transform);
            m_pool[i].SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < m_pool.Length; i++)
        {
            if (m_pool[i].activeInHierarchy == false)
            {
                m_pool[i].SetActive(true);
                return;
            }
        }
    }
}
