using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    static ResourcesManager _instance;

    public Object Load(string _path)
    {
        return Resources.Load(_path);
    }

    public T Load<T>(string _path) where T : Object
    {
        return Resources.Load<T>(_path);
    }

    public static ResourcesManager GetResourcesInstance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = "ResourceManager";
                go.AddComponent<ResourcesManager>();

                _instance = go.GetComponent<ResourcesManager>();
            }

            return _instance;
        }
    }
}
