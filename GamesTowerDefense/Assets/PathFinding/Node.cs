using UnityEngine;

[System.Serializable]
public class Node
{

    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int _coordinates, bool _isWalkable)
    {
        this.coordinates = _coordinates;
        this.isWalkable = _isWalkable;
    }
}
