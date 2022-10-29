using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mywaypoints : MonoBehaviour
{
    // Variable for tower prefab and logic for placeable
    [SerializeField] GameObject _towerPrefab;
    [SerializeField] bool _isPlaceable;

    private void OnMouseDown()
    {
        if (_isPlaceable)
        {
            //Debug.Log(transform.name);
            Instantiate(_towerPrefab, transform.position, Quaternion.identity);
            // Logic for only place one tower each location
            _isPlaceable = false;
        }
    }
}
