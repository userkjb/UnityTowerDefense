using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public Object Load(string _path)
    {
        return Resources.Load(_path);
    }

    public T Load<T>(string _path) where T : Object
    {
        return Resources.Load<T>(_path);
    }
}
