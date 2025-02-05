using System.Collections.Generic;
using UnityEngine;
using static ObjectEnum;

/// <summary>
/// Resource 들을 관리한다.
/// </summary>
public class ResourcesManager : Singleton<ResourcesManager>
{

    private Dictionary<string, Sprite> EnemyResources = new Dictionary<string, Sprite>();
    private Dictionary<string, Resources> TowerResources = new Dictionary<string, Resources>();


    public Object Load(string _path)
    {
        return Resources.Load(_path);
    }

    public T Load<T>(string _path) where T : Object
    {
        return Resources.Load<T>(_path);
    }

    public void Load<T>(string _path, ResourceType _Type = ResourceType.None) where T : Object
    {
        switch (_Type)
        {
            case ResourceType.None:
                {
                    Resources.Load<T>(_path);
                    break;
                }
            case ResourceType.Enemy:
                {
                    //$"Sprites/Enemy0{i}"
                    Object ob = Resources.Load<T>(_path);
                    Sprite sprite = ob as Sprite;
                    string name = _path;
                    name = name.Substring(name.Length - 7);
                    EnemyResources.Add(name, sprite);
                    break;
                }
            case ResourceType.Tower:
                {

                    break;
                }
            default:
                break;
        }
    }

    public Dictionary<string, Sprite> GetEnemyResources()
    {
        return EnemyResources;
    }

    public Sprite GetEnemySprite(string _EnemyNum)
    {
        return EnemyResources[_EnemyNum];
    }
}
