using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyDataGames/TowerData")]
public class TowerDataSCO : ScriptableObject
{
    // Tower Prefab
    public GameObject towerPrefab;

    // General type of Tower
    [Header("Tower Biography")]
    public int towerId;
    public string towerName;
    public string towerDescription;

    // Stats for Tower
    [Header("Tower PrimaryStats")]
    public int towerFuel;
    public float towerCooldown;

    //Secondary stats for tower
    [Header("Tower SecondaryStats")]
    public int towerHealth;
    public int towerDamage;
    public float towerSpeed;
    public float towerAttackSpeed;
}
