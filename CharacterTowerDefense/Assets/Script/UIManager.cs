using System.Collections.Generic;
using UnityEngine;
using static ObjectEnum;

public class UIManager : Singleton<UIManager>
{
    private GameObject MainCanvas = null;
    private Dictionary<string, GameObject> TowerUI = new Dictionary<string, GameObject>();


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
        if(!ResourcesManager.Instance.IsResource("TowerPanel"))
        {
            ResourcesManager.Instance.Load<GameObject>("Prefab/TowerPanel", ResourceType.UI);
        }
        if(!ResourcesManager.Instance.IsResource("UIImage"))
        {
            ResourcesManager.Instance.Load<GameObject>("Prefab/UIImage", ResourceType.UI);
        }


        GameObject Prefab = ResourcesManager.Instance.GetPrefab(_Name);
        GameObject go = Instantiate(Prefab);
        TowerUI.Add(_Name, go);
        return go;
    }
}
