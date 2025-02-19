using System.Collections.Generic;
using UnityEngine;
using static ObjectEnum;

public class UIManager : Singleton<UIManager>
{
    private GameObject MainCanvas = null;
    private Dictionary<string, GameObject> TowerUI = new Dictionary<string, GameObject>();

    public GameObject GetTowerUI(string _Name)
    {
        return TowerUI[_Name];
    }

    public void AddCanvas(GameObject _Can)
    {
        if(MainCanvas == null)
        {
            MainCanvas = _Can;
        }
    }

    public GameObject GetCanvas()
    {
        return MainCanvas;
    }

    public GameObject CreatePanel(string _Name)
    {
        if(!ResourcesManager.Instance.IsPrefab("TowerPanel"))
        {
            ResourcesManager.Instance.Load<GameObject>("Prefab/TowerPanel", ResourceType.UI);
        }
        
        GameObject Prefab = ResourcesManager.Instance.GetPrefab(_Name);
        GameObject go = Instantiate(Prefab);
        TowerUI.Add(_Name, go);
        return go;
    }

    public GameObject CreateUIImage(string _Name)
    {
        if (!ResourcesManager.Instance.IsPrefab("UIImage"))
        {
            ResourcesManager.Instance.Load<GameObject>("Prefab/UIImage", ResourceType.UI);
        }

        GameObject Prefab = ResourcesManager.Instance.GetPrefab(_Name);
        GameObject go = Instantiate(Prefab);
        TowerUI.Add(_Name, go);
        return go;
    }

    public GameObject CreateUIText(string _Name, int _Count)
    {
        if (!ResourcesManager.Instance.IsPrefab("UIText"))
        {
            ResourcesManager.Instance.Load<GameObject>("Prefab/UIText", ResourceType.UI);
        }

        // �ߺ� üũ
        if (IsTowerUI($"{_Name}{_Count}"))
        {
            Debug.LogError("Duplication");
            return null;
        }

        GameObject Prefab = ResourcesManager.Instance.GetPrefab(_Name);
        Prefab.name = $"{_Name}{_Count}";
        GameObject go = Instantiate(Prefab);
        TowerUI.Add($"{_Name}{_Count}", go);
        return go;
    }

    public bool IsTowerUI(string _Name)
    {
        bool Is = TowerUI.ContainsKey(_Name);
        return Is;
    }
}
