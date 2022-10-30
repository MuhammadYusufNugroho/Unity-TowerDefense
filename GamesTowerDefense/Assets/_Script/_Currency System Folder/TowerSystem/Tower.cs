using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Variables for cost
    [SerializeField] int _cost = 75;

    // Creating method CreateTower to Waypoints Script, we are using bool cuz later on we're gonna set this to false
    public bool CreateTower(Tower tower, Vector3 position)
    {
        // Reference to Banking Class
        Banking m_Banking = FindObjectOfType<Banking>();

        if (m_Banking == null) { return false; }

        if (m_Banking.CurrentBalance >= _cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            m_Banking.Withdraw(_cost);
            return true;
        }

        return false;
    }
}
