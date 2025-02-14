using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float SpawnTime = -1.0f;
    private int SpawnEnemyCount = -1;
    private int CurrentEnemyCount = 0;
    private int WaveCount = 0;

    public void SettingEnemySpawn(int _SpawnEnemyCount, int _WaveCount, float _SpawnTime)
    {
        this.SpawnTime = _SpawnTime;
        this.SpawnEnemyCount = _SpawnEnemyCount;
        this.WaveCount = _WaveCount;

        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        CurrentEnemyCount = ObjectManager.Instance.GetEnemys().Count;

        while (CurrentEnemyCount < SpawnEnemyCount)
        {
            ObjectManager.Instance.SpawnEnemy(this.transform.position, WaveCount);
            CurrentEnemyCount = ObjectManager.Instance.GetEnemys().Count;

            yield return new WaitForSeconds(SpawnTime);
        }
    }
}
