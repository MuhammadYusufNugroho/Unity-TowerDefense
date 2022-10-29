using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variable for  goldReward and goldPenalty
    [SerializeField] int m_goldReward = 25;
    [SerializeField] int m_goldPenalty = 25;

    //Referencing the Banking Class
    Banking m_Banking;

    // Start is called before the first frame update
    void Awake()
    {
        //Find the reference of Banking Class
        m_Banking = FindObjectOfType<Banking>();
    }

    /*
        -> EnemyHealth gonna call the Enemy class
        if the enemy health die, telling enemy class to increase the bank
        by the logic and passing the bank to deposit the money
        -> Enemey Health -> Enemy Class -> Banking Class
    */

    #region We are telling the bank to deposit or withdraw
    public void RewardGold()
    {
        if (m_Banking == null)
            return;
        m_Banking.Deposit(m_goldReward);
    }
    public void StealGold()
    {
        if (m_Banking == null)
            return;
        m_Banking.Withdraw(m_goldPenalty);
    }
    #endregion
}
