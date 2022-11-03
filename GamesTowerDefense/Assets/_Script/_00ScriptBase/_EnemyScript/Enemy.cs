using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variable for  goldReward and goldPenalty
    [SerializeField] int m_goldReward = 25;
    [SerializeField] int m_goldPenalty = 25;

    //Referencing the Banking Class
    Banking bank;

    // Start is called before the first frame update
    void Awake()
    {
        //Find the reference of Banking Class
        bank = FindObjectOfType<Banking>();
    }

    public void RewardGold()
    {
        if (bank == null) { return; }
        bank.Deposit(m_goldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(m_goldPenalty);
    }


}
