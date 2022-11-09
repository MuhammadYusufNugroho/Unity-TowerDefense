using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] int durationEnemy = 5;
    [SerializeField] GameObject targetPos;

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawningEnemy();
    }

    private void SpawningEnemy()
    {
        enemyPrefab.SetActive(true);
        enemyPrefab.transform.DOMove(targetPos.transform.position, durationEnemy);
    }

}
