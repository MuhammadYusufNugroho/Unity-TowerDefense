using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyDataGames/Enemydata")]
public class EnemyDataSCO : ScriptableObject
{
    // Enemy Prefab
    public GameObject enemyPrefab;
    // General type of enemy
    public int enemyId;
    public string enemyName;
    public string enemyDescription;
    // Stats for enemy
    public int enemyHealth;
    public float enemySpeed;
    public float enemyDetectRange;
    // Stats for damage
    public int enemyDamage;
    /*
     -> Discuss stats an any data for the object
    */

}
