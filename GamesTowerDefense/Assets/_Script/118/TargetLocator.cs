using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform _weapon;
    Transform _target;

    private void Awake()
    {
        //_target = FindObjectOfType<EnemyMover>().transform;
    }

    private void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        _weapon.LookAt(_target);
    }
}
