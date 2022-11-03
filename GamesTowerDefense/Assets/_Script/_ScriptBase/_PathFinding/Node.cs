using UnityEngine;

[System.Serializable]
public class Node
{
    // Creating pure variable for access in another class
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;
    // Constructor for Variable Vector2Int and bool isWalkable
    public Node(Vector2Int _coordinates, bool _isWalkable)
    {
        this.coordinates = _coordinates;
        this.isWalkable = _isWalkable;
    }
}
