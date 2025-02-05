using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임에 만들어지는 Object들을 관리한다.
/// </summary>
public class ObjectManager : Singleton<ObjectManager>
{
    private GameObject EnemyPrefab = null;
    private GameObject StartPointPrefab = null;
    private GameObject WayPointPrefab = null;
    private GameObject EnemySpawnerPrefab = null;
    private GameObject EndPointPrefab = null;

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


    private void Start()
    {
        
    }

    public void PrefabLoad()
    {
        EnemyPrefab = Resources.Load<GameObject>("Prefab/Enemy");
        StartPointPrefab = Resources.Load<GameObject>("Prefab/StartPoint");
        WayPointPrefab = Resources.Load<GameObject>("Prefab/WayPoint");
        EnemySpawnerPrefab = Resources.Load<GameObject>("Prefab/EnemySpawner");
        EndPointPrefab = Resources.Load<GameObject>("Prefab/EndPoint");
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
        Enem.EnemySetting();
        EnemyCount++;

        Enemys.Add(Enem);
    }

    public void SpawnStartPoint()
    {
        if(StartPointPrefab == null)
        {
            Debug.LogError("Start Point Prefab Is Null");
            return;
        }

        Instantiate(StartPointPrefab, StartPointPrefab.transform.position, Quaternion.Euler(0, 0, 0));

        WayPoints.Add(StartPointPrefab);
    }


    public void SpawnWaypoint(List<Vector2> _Pos)
    {
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
        Instantiate(EnemySpawnerPrefab, EnemySpawnerPrefab.transform.position, Quaternion.Euler(0, 0, 0));
    }

    public void SpawnEndPoint()
    {
        if (EndPointPrefab == null)
        {
            Debug.LogError("End Point Prefab Is Null");
            return;
        }
        Instantiate(EndPointPrefab, EndPointPrefab.transform.position, Quaternion.Euler(0, 0, 0));

        WayPoints.Add(EndPointPrefab);
    }

    public GameObject GetEndPoint()
    {
        if (EndPointPrefab == null)
        {
            Debug.LogError("End Point Prefab Is Null!");
            return null;
        }
        return EndPointPrefab;
    }
}
