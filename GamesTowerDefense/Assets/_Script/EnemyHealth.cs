using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int m_MaxHitPoint = 5;
    [SerializeField] int m_CurrentHitPoint = 0;

    // Start is called before the first frame update
    void OnEnable()
    {
        m_CurrentHitPoint = m_MaxHitPoint;
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
        }
    }
}
