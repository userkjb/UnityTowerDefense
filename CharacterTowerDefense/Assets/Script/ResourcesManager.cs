using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using static ObjectEnum;

/// <summary>
/// Resource 들을 관리한다.
/// </summary>
public class ResourcesManager : Singleton<ResourcesManager>
{
    private Dictionary<string, Sprite> AllResources = new Dictionary<string, Sprite>();
    private Dictionary<string, GameObject> AllPrefab = new Dictionary<string, GameObject>();


    //public Object Load(string _path)
    //{
    //    return Resources.Load(_path);
    //}
    //public T Load<T>(string _path) where T : Object
    //{
    //    return Resources.Load<T>(_path);
    //}

    public void Load<T>(string _path, ResourceType _Type = ResourceType.None) where T : Object
    {
        string name = _path;
        switch (_Type)
        {
            case ResourceType.None:
                {
                    Resources.Load<T>(_path);
                    break;
                }
            case ResourceType.Prefab:
                {
                    // Prefab/Enemy
                    Object ob = Resources.Load<T>(_path);
                    GameObject go = ob as GameObject;
                    name = name.Substring(7);
                    AllPrefab.Add(name, go);
                    break;
                }
            case ResourceType.Enemy:
                {
                    //$"Sprites/Enemy0{i}"
                    Object ob = Resources.Load<T>(_path);
                    Sprite sprite = ob as Sprite;
                    name = name.Substring(name.Length - 7);
                    AllResources.Add(name, sprite);
                    break;
                }
            case ResourceType.Tower:
                {
                    // $"Sprites/Tower0i_Lv0k"
                    Object ob = Resources.Load<T>(_path);
                    Sprite sprite = ob as Sprite;
                    name = name.Substring(name.Length - 12);
                    AllResources.Add(name, sprite);
                    break;
                }
            case ResourceType.Bullet:
                {
                    // Sprites/Projectile01
                    Object ob = Resources.Load<T>(_path);
                    Sprite sprite = ob as Sprite;
                    name = name.Substring(8);
                    AllResources.Add(name, sprite);
                    break;
                }
            case ResourceType.UI:
                {
                    Object ob = Resources.Load<T>(_path);
                    Sprite sprite = ob as Sprite;
                    name = name.Substring(1);
                    if(name == "UI")
                    {
                        AllResources.Add(name, sprite);
                    }
                    break;
                }
            default:
                break;
        }
    }

    public Sprite GetSprite(string _TowerName)
    {
        return AllResources[_TowerName];
    }

    public GameObject GetPrefab(string _PrefabName)
    {
        return AllPrefab[_PrefabName];
    }
}
