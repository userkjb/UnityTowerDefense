using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Coordinates : MonoBehaviour
{
    private List<float2> WaypointPosition = new List<float2>();


    private void Start()
    {
        WaypointPosition.Add(new float2(-7.5f, 0.5f));
        WaypointPosition.Add(new float2(7.5f, 0.5f));
        WaypointPosition.Add(new float2(7.5f, 3.5f));
        WaypointPosition.Add(new float2(4.5f, 3.5f));
        WaypointPosition.Add(new float2(4.5f, -4.5f));
        WaypointPosition.Add(new float2(7.5f, -4.5f));
        WaypointPosition.Add(new float2(7.5f, -1.5f));
        WaypointPosition.Add(new float2(-7.5f, -1.5f));
        WaypointPosition.Add(new float2(-7.5f, -4.5f));
        WaypointPosition.Add(new float2(-4.5f, -4.5f));
    }

    public List<float2> GetWaypointPos()
    {
        return WaypointPosition;
    }
}
