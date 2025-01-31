using UnityEngine;

public class StartPoint : MonoBehaviour
{

    private float EnemySpawnTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawnTime += Time.deltaTime;

        // 1초 마다 Enemy 생성.
        if(EnemySpawnTime >= 1.0f)
        {
            EnemySpawnTime = 0.0f;

            ObjectManager.Instance.SpawnEnemy();
        }
    }
}
