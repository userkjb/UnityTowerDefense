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
    /// ¾î¶»°Ô Á×À½?
    /// </summary>
    public enum EDestroyType
    {
        Kill,   // Å³.
        Arrive, // µµÂø.
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
