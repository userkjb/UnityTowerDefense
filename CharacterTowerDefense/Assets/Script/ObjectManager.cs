using UnityEngine;

/// <summary>
/// ���ӿ� ��������� Object���� �����Ѵ�.
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
