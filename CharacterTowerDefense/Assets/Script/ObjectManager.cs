using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static ObjectEnum;

/// <summary>
/// 게임에 만들어지는 Object들을 관리한다.
/// </summary>
public class ObjectManager : Singleton<ObjectManager>
{
    //private GameObject EnemyPrefab = null;
    //private GameObject StartPointPrefab = null;
    //private GameObject WayPointPrefab = null;
    //private GameObject EnemySpawnerPrefab = null;
    //private GameObject EndPointPrefab = null;
    //private GameObject TowerPrefab = null;

    private List<Enemy> Enemys = new List<Enemy>();
    public List<Enemy> GetEnemys()
    {
        return Enemys;
    }
    private int EnemyCount = 0;

    /// <summary>
    /// WayPoint 보관.
    /// </summary>
    private List<GameObject> WayPoints = new List<GameObject>();
    public List<GameObject> GetWayPoints()
    {
        return WayPoints;
    }

    private List<Tower> Towers = new List<Tower>();
    public List<Tower> GetTowers()
    {
        return Towers;
    }

    public void PrefabLoad()
    {
        ResourcesManager.Instance.Load<GameObject>("Prefab/Enemy", ResourceType.Prefab);
        ResourcesManager.Instance.Load<GameObject>("Prefab/StartPoint", ResourceType.Prefab);
        ResourcesManager.Instance.Load<GameObject>("Prefab/WayPoint", ResourceType.Prefab);
        ResourcesManager.Instance.Load<GameObject>("Prefab/EnemySpawner", ResourceType.Prefab);
        ResourcesManager.Instance.Load<GameObject>("Prefab/EndPoint", ResourceType.Prefab);
        ResourcesManager.Instance.Load<GameObject>("Prefab/Tower", ResourceType.Prefab);
    }

    public void SpawnEnemy(Vector3 _Pos)
    {
        GameObject EnemyPrefab = ResourcesManager.Instance.GetPrefab("Enemy");
        if (EnemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab is Null");
            return;
        }

        GameObject go = Instantiate(EnemyPrefab, _Pos, Quaternion.Euler(0, 0, 0));
        Enemy EnemObject = go.GetComponent<Enemy>();
        EnemObject.name = $"Enemy_{EnemyCount}";
        EnemObject.EnemySetting();
        EnemyCount++;

        Enemys.Add(EnemObject);
    }

    public void DestroyEnemy(Enemy _Enemy)
    {
        Enemys.Remove(_Enemy);
        Destroy(_Enemy.gameObject);
    }

    public void SpawnStartPoint()
    {
        GameObject StartPointPrefab = ResourcesManager.Instance.GetPrefab("StartPoint");
        if(StartPointPrefab == null)
        {
            Debug.LogError("Start Point Prefab Is Null");
            return;
        }

        Instantiate(StartPointPrefab, StartPointPrefab.transform.position, Quaternion.identity);

        WayPoints.Add(StartPointPrefab);
    }

    public void SpawnWaypoint(List<Vector2> _Pos)
    {
        GameObject WayPointPrefab = ResourcesManager.Instance.GetPrefab("WayPoint");
        int PositionCount = _Pos.Count;

        if(PositionCount == 0)
        {
            Debug.LogError("Is Not WayPoint XY Position Value");
            return;
        }
        if (WayPointPrefab == null)
        {
            Debug.LogError("Is Not WayPointPrefab");
            return;
        }

        for (int i = 0; i < PositionCount; i++)
        {
            Vector3 WaypointPos = _Pos[i];
            GameObject WayPoint = Instantiate(WayPointPrefab);
            WayPoint.transform.position = new Vector3(WaypointPos.x, WaypointPos.y, WaypointPos.z);

            WayPoints.Add(WayPoint);
        }
    }

    public void SpawnEnemySpawner()
    {
        GameObject EnemySpawnerPrefab = ResourcesManager.Instance.GetPrefab("EnemySpawner");
        if(EnemySpawnerPrefab == null)
        {
            Debug.LogError("Enemy Spawner Prefab Is Null");
            return;
        }
        Instantiate(EnemySpawnerPrefab, EnemySpawnerPrefab.transform.position, Quaternion.identity);
    }

    public void SpawnEndPoint()
    {
        GameObject EndPointPrefab = ResourcesManager.Instance.GetPrefab("EndPoint");
        if (EndPointPrefab == null)
        {
            Debug.LogError("End Point Prefab Is Null");
            return;
        }
        Instantiate(EndPointPrefab, EndPointPrefab.transform.position, Quaternion.identity);

        WayPoints.Add(EndPointPrefab);
    }

    public void SpawnTower(Vector3 _Pos)
    {
        GameObject TowerPrefab = ResourcesManager.Instance.GetPrefab("Tower");
        if (TowerPrefab == null)
        {
            return;
        }
        GameObject go = Instantiate(TowerPrefab, _Pos, Quaternion.identity); // identity = 회전 없음.
        Tower TowerObject = go.GetComponent<Tower>();
        Towers.Add(TowerObject);
    }
}
