using System;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform m_Weapon;
    [SerializeField] ParticleSystem _projectileParticles;
    [SerializeField] float _range = 15f;
    Transform m_Target;

    private void Awake()
    {
        m_Target = FindObjectOfType<EnemyMover>().transform;
    }

    private void Update()
    {
        FindCloseTarget();
        AimWeapon();
    }

    private void FindCloseTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }

            m_Target = closestTarget;
        }
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, m_Target.position);

        m_Weapon.LookAt(m_Target);

        if (targetDistance < _range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = _projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
