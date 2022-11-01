using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLableler : MonoBehaviour
{
    // Reference Waypoint Script
    //WayPoint waypoint;
    //Reference Grid
    GridManager m_gridManager;
    [SerializeField] Color _defaultColor = Color.white;
    [SerializeField] Color _blockedColor = Color.grey;
    [SerializeField] Color _exploredColor = Color.yellow;
    [SerializeField] Color _pathColor = new Color(1f ,0.5f ,0);

    // Reference for label and coordinates
    TextMeshPro m_Label;
    Vector2Int m_Coordinates = new Vector2Int();

    public void Awake()
    {
        // Find reference of object
        m_Label = GetComponent<TextMeshPro>();
        m_Label.enabled = false;

        //waypoint = GetComponentInParent<WayPoint>();
        m_gridManager = FindObjectOfType<GridManager>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {

        // Logic for application is playing or not
        if(!Application.isPlaying)
        {
            m_Label.enabled = true;
            //Debug.Log("it is works");
            DisplayCoordinates();
            UpdateObjectName();
        }
        // Calling method 
        SetLabelColor();
        ToggleLabels();
    }

    private void ToggleLabels()
    {
        // Logic for checkcing the label if it's not enable
        if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            m_Label.enabled = !m_Label.IsActive();
        }
    }

    private void SetLabelColor()
    {
        if(m_gridManager == null)
        { return; }

        Node node = m_gridManager.GetNode(m_Coordinates);

        if(node == null)
        { return; }

        if(!node.isWalkable)
        {
            m_Label.color = _blockedColor;
        }
        else if(node.isPath)
        {
            m_Label.color = _pathColor;
        }
        else if(node.isExplored)
        {
            m_Label.color = _exploredColor;
        }
        else
        {
            m_Label.color = _defaultColor;
        }


        /*
        // Logic for changing the colors
        if (waypoint.IsPlaceable)
            m_Label.color = _defaultColor;
        else
            m_Label.color = _blockedColor;
        */
    }

    public void DisplayCoordinates()
    {
        // Displaying the coordinates for the tiles
        if(m_gridManager == null)
        {
            return;
        }

        m_Coordinates.x = Mathf.RoundToInt(transform.parent.position.x / m_gridManager.myUnityGridSize);
        m_Coordinates.y = Mathf.RoundToInt(transform.parent.position.z / m_gridManager.myUnityGridSize);

        m_Label.text = m_Coordinates.x + "," + m_Coordinates.y;
    }

    public void UpdateObjectName()
    {
        // Displaying the name of the tiles
        transform.parent.name = m_Coordinates.ToString();
    }
}