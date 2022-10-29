using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<WayPoint> m_Path = new List<WayPoint>();
    [SerializeField] float m_waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Starting Here");
        StartCoroutine(FollowPath());
        //Debug.Log("finishing start");
    }

    public IEnumerator FollowPath()
    {
        foreach(WayPoint wayPoint in m_Path)
        {
            //Debug.Log(wayPoint.name);
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(m_waitTime);
        }
    }
}
