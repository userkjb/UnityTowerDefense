using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    private float EnemySpawnTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (EnemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab Is Null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawnTime += Time.deltaTime;

        // 1段 原陥 Enemy 持失.
        if(EnemySpawnTime >= 1.0f)
        {
            EnemySpawnTime = 0.0f;

            Instantiate(EnemyPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
