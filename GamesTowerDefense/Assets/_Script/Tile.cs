using UnityEngine;

public class Tile : MonoBehaviour
{
    // Variable for tower prefab and logic for placeable
    [SerializeField] Tower m_TowerPrefab;
    // Properties for isPlaceable
    [SerializeField] bool m_IsPlaceable;
    public bool IsPlaceable { get { return m_IsPlaceable; } }

    GridManager m_GridManager;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        m_GridManager = FindObjectOfType<GridManager>();
    }

    private void Start()
    {
        if(m_GridManager != null)
        {
            coordinates = m_GridManager.GetCoordinatesFromPosition(transform.position);

            if(!IsPlaceable)
            {
                m_GridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if(m_IsPlaceable)
        {
            bool isPlaced = m_TowerPrefab.CreateTower(m_TowerPrefab ,transform.position);

            // Logic for only place one tower each location
            m_IsPlaceable = !isPlaced;
        }
    }
}
