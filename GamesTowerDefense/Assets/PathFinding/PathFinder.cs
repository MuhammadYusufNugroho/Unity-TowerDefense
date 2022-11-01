using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right ,Vector2Int.left ,Vector2Int.up ,Vector2Int.down };
    GridManager m_gridManager;
    Dictionary<Vector2Int ,Node> grid;


    private void Awake()
    {
        m_gridManager = FindObjectOfType<GridManager>();
        if(m_gridManager != null)
        {
            grid = m_gridManager.Grid;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ExploreNeighbors();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
            if(grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);

                grid[neighborCoords].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
