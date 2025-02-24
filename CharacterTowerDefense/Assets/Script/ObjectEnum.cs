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
        UI,
    }

    public enum ETowerState
    {
        None,
        SearchTarget,
        Attack,
    }

    /// <summary>
    /// ��� ����?
    /// </summary>
    public enum EDestroyType
    {
        Kill,   // ų.
        Arrive, // ����.
    }

    public enum ETextType
    {
        None,
        Damage,
        Rate,
        Range,
        Level,
    }
}
