using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLableler : MonoBehaviour
{
    TextMeshPro m_Label;
    Vector2Int m_Coordinates = new Vector2Int();

    public void Awake()
    {
        m_Label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            //Debug.Log("it is works");
            DisplayCoordinates();
            UpdateObjectName();

        }
    }

    public void DisplayCoordinates()
    {
        m_Coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        m_Coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        m_Label.text = m_Coordinates.x + "," + m_Coordinates.y;
    }

    public void UpdateObjectName()
    {
        transform.parent.name = m_Coordinates.ToString();
    }
}
