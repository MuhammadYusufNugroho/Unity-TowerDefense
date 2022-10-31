using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Variable for tower prefab and logic for placeable
    [SerializeField] Tower m_TowerPrefab;
    // Properties for isPlaceable
    [SerializeField] bool m_IsPlaceable;
    public bool IsPlaceable { get { return m_IsPlaceable; } }

    private void OnMouseDown()
    {
        if (m_IsPlaceable)
        {
            bool isPlaced = m_TowerPrefab.CreateTower(m_TowerPrefab, transform.position);

            // Logic for only place one tower each location
            m_IsPlaceable = !isPlaced;
        }
    }
}
