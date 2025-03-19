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

    public Canvas GetCanvas()
    {
        if(null == MainCanvas)
        {
            return null;
        }
        else
        {
            return MainCanvas.GetComponent<Canvas>();
        }
    }

    public GameObject CreatePanel(string _Name)
    {
        if(!ResourcesManager.Instance.IsPrefab($"{_Name}"))
        {
            ResourcesManager.Instance.Load<GameObject>($"Prefab/{_Name}", ResourceType.Prefab);
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
            ResourcesManager.Instance.Load<GameObject>("Prefab/UIImage", ResourceType.Prefab);
        }

        // 중복 체크
        if (IsTowerUI(_Name))
        {
            Debug.LogError("Overlapping Image UI");
            return null;
        }

        GameObject Prefab = ResourcesManager.Instance.GetPrefab(_Name);
        GameObject go = Instantiate(Prefab);
        TowerUI.Add(_Name, go);
        return go;
    }

    public GameObject CreateTowerUIText(string _Name, int _Count)
    {
        if (!ResourcesManager.Instance.IsPrefab("UIText"))
        {
            ResourcesManager.Instance.Load<GameObject>("Prefab/UIText", ResourceType.Prefab);
        }

        // 중복 체크
        if (IsTowerUI($"{_Name}{_Count}"))
        {
            Debug.LogError("Overlapping Test UI");
            return null;
        }

        GameObject Prefab = ResourcesManager.Instance.GetPrefab(_Name);
        Prefab.name = $"{_Name}{_Count}";
        GameObject go = Instantiate(Prefab);
        TowerUI.Add($"{_Name}{_Count}", go);
        return go;
    }

    public GameObject CreateButton(string _Btn_Name)
    {
        if (!ResourcesManager.Instance.IsPrefab("UIButton"))
        {
            ResourcesManager.Instance.Load<GameObject>("Prefab/UIButton", ResourceType.Prefab);
        }
        if (!ResourcesManager.Instance.IsPrefab("UIText"))
        {
            ResourcesManager.Instance.Load<GameObject>("Prefab/UIText", ResourceType.Prefab);
        }

        // TODO Upgrage or Sell
        if (IsTowerUI($"{_Btn_Name}"))
        {
            Debug.LogError("Overlapping Button UI");
            return null;
        }

        GameObject Prefab = ResourcesManager.Instance.GetPrefab("UIButton");
        Prefab.name = $"{_Btn_Name}";

        GameObject TextPrefab = ResourcesManager.Instance.GetPrefab("UIText");
        TextPrefab.name = "Text";
        
        GameObject go_Text = Instantiate(TextPrefab);
        GameObject go_Btn = Instantiate(Prefab);

        go_Btn.GetComponent<UIButton>().SetBtnInTextUI(go_Text.GetComponent<UIText>());
        
        TowerUI.Add(_Btn_Name, go_Btn);
        return go_Btn;
    }

    public bool IsTowerUI(string _Name)
    {
        bool Is = TowerUI.ContainsKey(_Name);
        return Is;
    }

    /// <summary>
    /// Data Is Tower.
    /// </summary>
    /// <returns></returns>
    public GameObject CreateTowerRangeUI()
    {
        GameObject Prefab = ResourcesManager.Instance.GetPrefab("UITowerAttackRange");
        GameObject go = Instantiate(Prefab);
        go.GetComponent<UITowerAttackRange>().SetComponent();
        return go;
    }
}
