using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour
{
    private readonly List<Vector2> WaypointPosition = new List<Vector2>();

    private void Awake()
    {
        WaypointPosition.Add(new Vector2(-7.5f, 0.5f));
        WaypointPosition.Add(new Vector2(7.5f, 0.5f));
        WaypointPosition.Add(new Vector2(7.5f, 3.5f));
        WaypointPosition.Add(new Vector2(4.5f, 3.5f));
        WaypointPosition.Add(new Vector2(4.5f, -4.5f));
        WaypointPosition.Add(new Vector2(7.5f, -4.5f));
        WaypointPosition.Add(new Vector2(7.5f, -1.5f));
        WaypointPosition.Add(new Vector2(-7.5f, -1.5f));
        WaypointPosition.Add(new Vector2(-7.5f, -4.5f));
        WaypointPosition.Add(new Vector2(-4.5f, -4.5f));
    }

    private void Start()
    {
    }

    public List<Vector2> GetWaypointPos()
    {
        return WaypointPosition;
    }
}
