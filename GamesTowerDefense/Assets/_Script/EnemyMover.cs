using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    Enemy enemy;

    [SerializeField] List<Tile> m_Path = new List<Tile>();
    [SerializeField][Range(0f ,5f)] float m_Speed = 1f;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        //Debug.Log("Starting Here");
        StartCoroutine(FollowPath());
        //Debug.Log("finishing start");
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Finding the path tag 
    void FindPath()
    {
        m_Path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Tile waypoint = child.GetComponent<Tile>();
            if(waypoint != null)
            {
                m_Path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = m_Path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(Tile wayPoint in m_Path)
        {
            //Debug.Log(wayPoint.name);
            Vector3 stratPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * m_Speed;
                transform.position = Vector3.Lerp(stratPosition ,endPosition ,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }

}
