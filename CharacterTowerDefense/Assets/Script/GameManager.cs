using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject WayPointPrefab;

    /// <summary>
    /// WayPoint Position Setting
    /// </summary>
    [SerializeField]
    private List<Vector2> WaypointPosition = new List<Vector2>();

    private List<GameObject> WayPoints = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        int a = 0;
    }


    private void CreateWaypoint()
    {
        if(WayPointPrefab == null)
        {
            Debug.LogError("Waypoint Prefab Is Null");
        }


        int WaypointPositionCount = WaypointPosition.Count;
        for (int i = 0; i < WaypointPositionCount; i++)
        {
            Vector3 WaypointPos = WaypointPosition[i];
            GameObject WayPoint = Instantiate(WayPointPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
            WayPoint.transform.position = new Vector3(WaypointPos.x, WaypointPos.y, WaypointPos.z);

            WayPoints.Add(WayPoint);
        }
    }
}
