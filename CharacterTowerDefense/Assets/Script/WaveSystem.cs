using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private int CurrentWaveIndex = 0; // 현재 Wave.
    [SerializeField]
    private int SettingSpawnEnemyCount = 0; // 한 Wave에서 생성할 Enemy 수.
    [SerializeField]
    private float EnemySpawnTime = 0.0f; // 적 생성 시간

    public int GetWaveValue()
    {
        return CurrentWaveIndex;
    }

    private void Update()
    {
        
    }


    public void Button_StartWave()
    {
        List<Enemy> Enemys = ObjectManager.Instance.GetEnemys();
        int EnemyCount = Enemys.Count;

        if (EnemyCount == 0)
        {
            CurrentWaveIndex++;
            if(CurrentWaveIndex == 6)
            {
                return;
            }

            EnemySpawner Enemy_Spawner = gameObject.GetComponent<EnemySpawner>();
            if(Enemy_Spawner != null)
            {
                Enemy_Spawner.SettingEnemySpawn(SettingSpawnEnemyCount, CurrentWaveIndex, EnemySpawnTime);
            }
        }
    }
}