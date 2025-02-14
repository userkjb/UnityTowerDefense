using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private int CurrentWaveIndex = 0; // ���� Wave.
    [SerializeField]
    private int SettingSpawnEnemyCount = 0; // �� Wave���� ������ Enemy ��.
    [SerializeField]
    private float EnemySpawnTime = 0.0f; // �� ���� �ð�

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