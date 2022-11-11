using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IPooledObject
{
    enum enemyState
    {
        enemySpawning,
        enemyMove,
        enemyAttack,
        enemyHit,
        enemyDeath
    }

    // Reference
    NavMeshAgent navMeshAgent;

    [SerializeField] GameObject referencePlayer;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        OnEnemySpawning();
        OnEnemyMove();
    }

    // Method For The Enemey
    private void OnEnemySpawning()
    {

    }

    private void OnEnemyMove()
    {
        //navMeshAgent.destination = referencePlayer.gameObject.transform.position;
    }



    public void OnObjectSpawn()
    {

    }
}
