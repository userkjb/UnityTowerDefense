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
    /// WayPoint 보관.
    /// </summary>
    private List<GameObject> WayPoints = new List<GameObject>();

    /// <summary>
    /// 각WayPoint들의 Position을 가지고 있는 Class
    /// </summary>
    private Coordinates Coordinate = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ComponentIsAdd();

        NullCheckFun();

        CreateStartPoint();
        CreateWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ComponentIsAdd()
    {
        {
            GameObject go = new GameObject();
            go.name = "Coordinates";
            go.AddComponent<Coordinates>();
            Coordinate = go.GetComponent<Coordinates>();
        }

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
        List<Vector2> WayPos = Coordinate.GetWaypointPos();
        int WayPosCount = WayPos.Count;
        for (int i = 0; i < WayPosCount; i++)
        {
            Vector3 WaypointPos = WayPos[i];
            GameObject WayPoint = Instantiate(WayPointPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
            WayPoint.transform.position = new Vector3(WaypointPos.x, WaypointPos.y, WaypointPos.z);

            WayPoints.Add(WayPoint);
        }

        //int WaypointPositionCount = WaypointPosition.Count;
        //for (int i = 0; i < WaypointPositionCount; i++)
        //{
        //    Vector3 WaypointPos = WaypointPosition[i];
        //    GameObject WayPoint = Instantiate(WayPointPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        //    WayPoint.transform.position = new Vector3(WaypointPos.x, WaypointPos.y, WaypointPos.z);
        //    WayPoints.Add(WayPoint);
        //}
    }

    public List<GameObject> GetWayPoints()
    {
        return WayPoints;
    }
}
