using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform m_Weapon;
    Transform m_Target;

    private void Awake()
    {
        m_Target = FindObjectOfType<EnemyMover>().transform;
    }

    private void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        m_Weapon.LookAt(m_Target);
    }
}
