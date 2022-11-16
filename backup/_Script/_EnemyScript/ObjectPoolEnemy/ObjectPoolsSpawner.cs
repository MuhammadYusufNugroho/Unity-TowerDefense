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
        if (levelManager.stopTimer == false)
            ObjectPools.Instance.SpawnFromPool("Cube", transform.position, transform.rotation);
        else if (levelManager.stopTimer == true)
            this.gameObject.SetActive(false);
    }
}