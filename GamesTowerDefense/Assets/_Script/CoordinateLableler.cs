using System;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteAlways]
public class CoordinateLableler : MonoBehaviour
{
    // Reference Waypoint Script
    WayPoint waypoint;
    [SerializeField] Color _defaultColor = Color.white;
    [SerializeField] Color _blockedColor = Color.grey;

    // Reference for label and coordinates
    TextMeshPro m_Label;
    Vector2Int m_Coordinates = new Vector2Int();

    public void Awake()
    {
        // Find reference of object
        m_Label = GetComponent<TextMeshPro>();
        m_Label.enabled = false;
        waypoint = GetComponentInParent<WayPoint>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        // Logic for application is playing or not
        if (!Application.isPlaying)
        {
            //Debug.Log("it is works");
            DisplayCoordinates();
            UpdateObjectName();
        }
        // Calling method 
        ColorCoordinates();
        ToggleLabels();
    }

    private void ToggleLabels()
    {
        // Logic for checkcing the label if it's not enable
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            m_Label.enabled = !m_Label.IsActive();
        }
    }

    private void ColorCoordinates()
    {
        // Logic for changing the colors
        if (waypoint.IsPlaceable)
            m_Label.color = _defaultColor;
        else
            m_Label.color = _blockedColor;

    }

    public void DisplayCoordinates()
    {
        // Displaying the coordinates for the tiles
        m_Coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        m_Coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        m_Label.text = m_Coordinates.x + "," + m_Coordinates.y;
    }

    public void UpdateObjectName()
    {
        // Displaying the name of the tiles
        transform.parent.name = m_Coordinates.ToString();
    }
}
