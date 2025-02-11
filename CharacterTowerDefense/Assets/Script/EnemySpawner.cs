using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float CalTime = 0.0f;

    [SerializeField]
    private float EnemySpawnTime = 0.0f; // 적 생성 시간

    private int SpawnCount = 0;
    [SerializeField]
    private int SettingSpawnCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SettingSpawnCount == SpawnCount)
        {
            return;
        }

        CalTime += Time.deltaTime;

        if (CalTime >= EnemySpawnTime)
        {
            CalTime = 0.0f;

            ObjectManager.Instance.SpawnEnemy(this.transform.position);
            SpawnCount++;
        }
    }
}
