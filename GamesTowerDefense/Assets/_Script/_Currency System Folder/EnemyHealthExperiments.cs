using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthExperiments : MonoBehaviour
{
    //Reference Enemy Class
    Enemy m_Enemy;

    private void Start()
    {
        //Find the Reference Enemy Class
        m_Enemy = GetComponent<Enemy>();
    }

    /*
        Adding the reward gold to process hit in after setActive
        m_enemy.RewardGold();

        Adding the reward gold to process hit in after setActive in EnemyMover Class
        m_enemy.StealGold();
    */
}
