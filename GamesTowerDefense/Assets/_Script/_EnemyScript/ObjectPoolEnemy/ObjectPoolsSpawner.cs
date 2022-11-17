using UnityEngine;

public class ObjectPoolsSpawner : MonoBehaviour
{
    LevelManager levelManager;
    private void FixedUpdate()
    {
        StopingSpawn();
    }

    private void StopingSpawn()
    {
        levelManager = LevelManager.Instance;
        if (levelManager._isStopTimer == false)
            ObjectPools.Instance.SpawnFromPool("Cube", transform.position, transform.rotation);
        else if (levelManager._isStopTimer == true)
            this.gameObject.SetActive(false);
    }
}
