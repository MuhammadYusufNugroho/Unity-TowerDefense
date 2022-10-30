using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Variable for tower prefab and logic for placeable
    [SerializeField] GameObject m_TowerPrefab;
    [SerializeField] bool m_IsPlaceable;

    private void OnMouseDown()
    {
        if(m_IsPlaceable)
        {
            //Debug.Log(transform.name);
            Instantiate(m_TowerPrefab ,transform.position ,Quaternion.identity);
            // Logic for only place one tower each location
            m_IsPlaceable = false;
        }
    }
}
