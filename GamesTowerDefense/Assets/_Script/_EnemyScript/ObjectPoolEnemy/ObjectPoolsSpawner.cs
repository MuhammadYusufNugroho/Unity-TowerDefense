using UnityEngine;

public class ObjectPoolsSpawner : MonoBehaviour
{
    TimeManager timeManager;
    private void FixedUpdate()
    {
        StopingSpawn();
    }

    private void StopingSpawn()
    {
        timeManager = TimeManager.Instance;
        if (timeManager._isStopTimer == false)
            ObjectPools.Instance.SpawnFromPool("Cube", transform.position, transform.rotation);
        else if (timeManager._isStopTimer == true)
            this.gameObject.SetActive(false);
    }
}
