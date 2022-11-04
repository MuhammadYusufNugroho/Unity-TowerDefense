using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyDataGames/PlayerData")]
public class PlayerDataSCO : ScriptableObject
{
    // Player Prefab
    public GameObject playerPrefab;
    // General type of Player
    public int playerId;
    public string playerName;
    public string playerDescription;
    // Stats for Player
    public int playerHealth;
    public float playerSpeed;
    public float playerDetectRange;
    // Stats for Player
    public int playerDamage;
    /*
     -> Discuss stats an any data for the object
    */
}
