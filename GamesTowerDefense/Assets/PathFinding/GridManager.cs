using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    Vector2Int m_gridSize;

    [Tooltip("World gird size - should match UnityEditor snap settings.")]
    [SerializeField]
    int unityGridSize = 10;
    public int myUnityGridSize { get { return myUnityGridSize; } }

    Dictionary<Vector2Int ,Node> grid = new Dictionary<Vector2Int ,Node>();
    public Dictionary<Vector2Int ,Node> Grid { get { return grid; } }

    void awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }
        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int m_Coordinates = new Vector2Int();

        m_Coordinates.x = Mathf.RoundToInt(position.x / myUnityGridSize);
        m_Coordinates.y = Mathf.RoundToInt(position.z / myUnityGridSize);

        return m_Coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }

    void CreateGrid()
    {
        for(int x = 0; x < m_gridSize.x; x++)
        {
            for(int y = 0; y < m_gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x ,y);
                grid.Add(coordinates ,new Node(coordinates ,true));
                //Debug.Log(grid[coordinates].coordinates + " = " + grid[coordinates].isWalkable);
            }
        }
    }
}
