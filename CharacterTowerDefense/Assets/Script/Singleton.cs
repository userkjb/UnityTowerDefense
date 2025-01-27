using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = typeof(T).Name; // C#에서 제공.
                go.AddComponent<T>();

                _instance = go.GetComponent<T>();
            }

            return _instance;
        }
    }
}
