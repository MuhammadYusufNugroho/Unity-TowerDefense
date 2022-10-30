using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<WayPoint> m_Path = new List<WayPoint>();
    [SerializeField][Range(0f, 5f)] float m_Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        ReturnToStart();
        //Debug.Log("Starting Here");
        StartCoroutine(FollowPath());
        //Debug.Log("finishing start");
    }

    // Finding the path tag
    void FindPath()
    {
        m_Path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (var waypoint in waypoints)
        {
            m_Path.Add(waypoint.GetComponent<WayPoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = m_Path[0].transform.position;
    }

    public IEnumerator FollowPath()
    {
        foreach (WayPoint wayPoint in m_Path)
        {
            //Debug.Log(wayPoint.name);
            Vector3 stratPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * m_Speed;
                transform.position = Vector3.Lerp(stratPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        Destroy(gameObject);
    }
}
