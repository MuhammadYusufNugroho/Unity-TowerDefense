using UnityEngine;

[CreateAssetMenu(menuName = "MyDataGames/EnemyData")]
public class EnemyDataSCO : ScriptableObject
{
    // Enemy Prefab
    public GameObject enemyPrefab;

    // General type of enemy
    [Header("Enemy Biography")]
    public int enemyId;
    public string enemyName;
    public string enemyDescription;

    // Stats for enemy
    [Header("Enemy PrimaryStats")]
    public int enemyHealth;
    public int enemyDamage;
    public float enemySpeed;
    public float enemyAttackSpeed;
}
