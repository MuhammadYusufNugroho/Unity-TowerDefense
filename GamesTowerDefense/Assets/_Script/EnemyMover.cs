using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<WayPoint> m_Path = new List<WayPoint>();

    // Start is called before the first frame update
    void Start()
    {
        PrintWayPointName();
    }

    public void PrintWayPointName()
    {
        foreach(WayPoint m_wayPoint in m_Path)
        {
            Debug.Log(m_wayPoint.name);
        }
    }
}
