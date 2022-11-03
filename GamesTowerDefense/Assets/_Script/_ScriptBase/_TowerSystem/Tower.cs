using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Variables for cost
    [SerializeField] int _cost = 75;
    [SerializeField] float buildDelay = 1f;

    private void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(true);
            }
        }
    }

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
