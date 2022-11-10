using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolsSpawner : MonoBehaviour
{


    private void start()
    {

    }

    private void FixedUpdate()
    {
        ObjectPools.Instance.SpawnFromPool("Cube", transform.position, transform.rotation);
    }
}
