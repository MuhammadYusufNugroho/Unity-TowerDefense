using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;

    [SerializeField] int m_MaxHitPoint = 5;
    int m_CurrentHitPoint = 0;

    [Tooltip("Adds amount to maxHitPointToEnemy when they're dies")]
    [SerializeField] int _difficultRamp = 1;

    // Start is called before the first frame update
    void OnEnable()
    {
        m_CurrentHitPoint = m_MaxHitPoint;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    public void ProcessHit()
    {
        m_CurrentHitPoint--;
        if (m_CurrentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            m_MaxHitPoint += _difficultRamp;
            enemy.RewardGold();
        }
    }
}
