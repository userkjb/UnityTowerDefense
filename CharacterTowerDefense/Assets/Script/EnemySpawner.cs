using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemySpawnPoint;

    private float EnemySpawnTime = 0.0f;

    // Get/Set
    public GameObject GetEnemySpawnPoint()
    {
        return EnemySpawnPoint;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (EnemySpawnPoint == null)
        {
            Debug.LogError("Enemy Spawn Point Is Null");
        }


    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawnTime += Time.deltaTime;

        // 1段 原陥 Enemy 持失.
        if (EnemySpawnTime >= 1.0f)
        {
            EnemySpawnTime = 0.0f;

            ObjectManager.Instance.SpawnEnemy(this.transform.position);
        }
    }
}
