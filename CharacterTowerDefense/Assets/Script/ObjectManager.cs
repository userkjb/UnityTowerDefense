using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ӿ� ��������� Object���� �����Ѵ�.
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



    public void SpawnEnemy(Vector3 _Pos)
    {
        if(EnemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab is Null");
            return;
        }

        GameObject go = Instantiate(EnemyPrefab, _Pos, Quaternion.Euler(0, 0, 0));
        Enemy Enem = go.GetComponent<Enemy>();
        Enem.name = $"Enemy_{EnemyCount}";
        EnemyCount++;

        Enemys.Add(Enem);
    }
}
