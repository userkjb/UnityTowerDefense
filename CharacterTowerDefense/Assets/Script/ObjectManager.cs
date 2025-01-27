using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임에 만들어지는 Object들을 관리한다.
/// </summary>
public class ObjectManager : Singleton<ObjectManager>
{
    GameObject EnemyPrefab;

    private List<Enemy> Enemys = new List<Enemy>();
    public List<Enemy> GetEnemys()
    {
        return Enemys;
    }
    private int EnemyCount = 0;

    

    private void Start()
    {
        PrefabLoad();
    }

    private void PrefabLoad()
    {
        EnemyPrefab = Resources.Load<GameObject>("Prefab/Enemy");
    }



    public void SpawnEnemy()
    {
        if(EnemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab is Null");
            return;
        }

        GameObject go = Instantiate(EnemyPrefab);
        Enemy Enem = go.GetComponent<Enemy>();
        Enem.name = $"Enemy_{EnemyCount}";
        EnemyCount++;

        Enemys.Add(Enem);
    }
}
