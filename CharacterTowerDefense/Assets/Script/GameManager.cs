using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static ObjectEnum;

public class GameManager : MonoBehaviour
{
    private int LevelNum = 0;
    public int GetLevelNum()
    {
        return LevelNum;
    }

    /// <summary>
    /// 각WayPoint들의 Position을 가지고 있는 Class
    /// </summary>
    private Coordinates Coordinate = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemySpriteLoad();

        ComponentIsAdd();

        CreatePoint();
        SpawnPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// WayPoint 좌표 가져오기.
    /// </summary>
    private void ComponentIsAdd()
    {
        {
            GameObject go = new GameObject();
            go.name = "Coordinates";
            go.AddComponent<Coordinates>();
            Coordinate = go.GetComponent<Coordinates>();
        }

    }

    private void CreatePoint()
    {
        ObjectManager.Instance.SpawnStartPoint();

        List<Vector2> WayPos = Coordinate.GetWaypointPos();
        ObjectManager.Instance.SpawnWaypoint(WayPos);

        ObjectManager.Instance.SpawnEndPoint();
    }

    private void SpawnPlayerStats()
    {
        ObjectManager.Instance.SpawnPlayerStats();
    }

    private void EnemySpriteLoad()
    {
        for (int i = 1; i <= 5; i++)
        {
            //ResourcesManager.Instance.Load<Sprite>($"Sprites/Enemy0{i}");
            ResourcesManager.Instance.Load<Sprite>($"Sprites/Enemy0{i}", ResourceType.Enemy);
        }

        for(int i = 1; i <= 3; i++)
        {
            for(int k = 1; k <= 3; k++)
            {
                ResourcesManager.Instance.Load<Sprite>($"Sprites/Tower0{i}_Lv0{k}", ResourceType.Tower);
            }
        }

        // Bullet
        {
            ResourcesManager.Instance.Load<Sprite>("Sprites/Projectile01", ResourceType.Bullet);
        }

        ObjectManager.Instance.PrefabLoad();
    }
}
