using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager
{
    public enum EnemyState
    {
        enemySpawn,
        enemyMove,
        enemyAttack,
        enemyHit,
        enemyDeath
    }
}
