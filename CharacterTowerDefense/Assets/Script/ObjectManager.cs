using UnityEngine;

/// <summary>
/// 게임에 만들어지는 Object들을 관리한다.
/// </summary>
public class ObjectManager : Singleton<ObjectManager>
{
    GameObject EnemyPrefab;

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
    }
}
