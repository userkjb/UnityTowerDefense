using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject WayPointPrefab;
    [SerializeField]
    private GameObject StartPointPrefab;

    private int LevelNum = 0;
    public int GetLevelNum()
    {
        return LevelNum;
    }

    /// <summary>
    /// WayPoint Position Setting
    /// </summary>
    [SerializeField]
    private List<Vector2> WaypointPosition = new List<Vector2>();

    /// <summary>
    /// WayPoint º¸°ü.
    /// </summary>
    private List<GameObject> WayPoints = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NullCheckFun();

        CreateStartPoint();
        CreateWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NullCheckFun()
    {
        if (WayPointPrefab == null)
        {
            Debug.LogError("Waypoint Prefab Is Null");
        }

        if(StartPointPrefab == null)
        {
            Debug.LogError("StartPoint Prefab Is Null");
        }
    }

    private void CreateStartPoint()
    {
        Instantiate(StartPointPrefab, StartPointPrefab.transform.position, Quaternion.Euler(0, 0, 0));
    }

    private void CreateWaypoint()
    {
        int WaypointPositionCount = WaypointPosition.Count;
        for (int i = 0; i < WaypointPositionCount; i++)
        {
            Vector3 WaypointPos = WaypointPosition[i];
            GameObject WayPoint = Instantiate(WayPointPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
            WayPoint.transform.position = new Vector3(WaypointPos.x, WaypointPos.y, WaypointPos.z);

            WayPoints.Add(WayPoint);
        }
    }

    public List<GameObject> GetWayPoints()
    {
        return WayPoints;
    }
}
