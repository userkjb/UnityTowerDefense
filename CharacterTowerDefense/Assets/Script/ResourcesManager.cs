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
    private Dictionary<string, Sprite> EnemyResources = new Dictionary<string, Sprite>();
    private Dictionary<string, Sprite> TowerResources = new Dictionary<string, Sprite>();


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
                    string name = _path;
                    name = name.Substring(7);
                    AllPrefab.Add(name, go);
                    break;
                }
            case ResourceType.Enemy:
                {
                    //$"Sprites/Enemy0{i}"
                    Object ob = Resources.Load<T>(_path);
                    Sprite sprite = ob as Sprite;
                    string name = _path;
                    name = name.Substring(name.Length - 7);
                    AllResources.Add(name, sprite);
                    break;
                }
            case ResourceType.Tower:
                {
                    // $"Sprites/Tower0i_Lv0k"
                    Object ob = Resources.Load<T>(_path);
                    Sprite sprite = ob as Sprite;
                    string name = _path;
                    name = name.Substring(name.Length - 12);
                    AllResources.Add(name, sprite);
                    break;
                }
            case ResourceType.Bullet:
                {
                    Resources.Load<T>(_path);
                    break;
                }
            default:
                break;
        }
    }

    public Sprite GetEnemySprite(string _EnemyNum)
    {
        return AllResources[_EnemyNum];
    }

    public Sprite GetTowerSprite(string _TowerName)
    {
        return AllResources[_TowerName];
    }

    public GameObject GetPrefab(string _PrefabName)
    {
        return AllPrefab[_PrefabName];
    }
}
