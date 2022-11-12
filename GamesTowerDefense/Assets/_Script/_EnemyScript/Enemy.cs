using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IPooledObject
{
    public enum enemyState
    {
        enemySpawning,
        enemyMove,
        enemyAttack,
        enemyHit,
        enemyDeath
    }

    public static Enemy Instance;
    // Reference
    NavMeshAgent navMeshAgent;

    [SerializeField] GameObject referencePlayer;

    private void Awake()
    {
        Instance = this;
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

    public void OnEnemyMove()
    {
        //navMeshAgent.destination = referencePlayer.gameObject.transform.position;
    }



    public void OnObjectSpawn()
    {

    }
}
