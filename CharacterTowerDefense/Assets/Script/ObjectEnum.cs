using UnityEngine;

public class ObjectEnum : MonoBehaviour
{
    public enum ResourceType
    {
        None,
        Prefab,
        Enemy,
        Tower,
        Bullet,
    }

    public enum TowerStatus
    {
        None,
        SearchTarget,
        Attack,
    }
}
