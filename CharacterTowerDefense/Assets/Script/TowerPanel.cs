using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ObjectEnum;

public class TowerPanel : MonoBehaviour
{
    private List<GameObject> TowerDataViews= new List<GameObject>();
    private GameObject TowerImage = null;
    private GameObject UpgradeBtn = null;
    private GameObject SellBtn = null;
    private Tower SelectTower = null;

    private void Awake()
    {
        GetComponent<RectTransform>().position = Vector3.zero;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RectTransform Transform = GetComponent<RectTransform>();
        Transform.anchorMin = new Vector2(0.5f, 0);
        Transform.anchorMax = new Vector2(0.5f, 0);
        Transform.anchoredPosition3D = new Vector3(0.0f, 43.0f, 0.0f);
        Transform.sizeDelta = new Vector2(100.0f, 87.0f);
        Transform.localScale = new Vector3(2.56f, 1.0f, 1.0f);

        CreateTowerImageView();
        CreateTowerDataViews();
        CreateTowerButton();

        OffTowerData();
    }

    private void CreateTowerImageView()
    {
        GameObject TowerImage = UIManager.Instance.CreateUIImage("UIImage");
        TowerImage.transform.SetParent(gameObject.transform);
        
        UIImage img = TowerImage.GetComponent<UIImage>();
        img.SetImageTransform();

        this.TowerImage = TowerImage;
    }

    private void CreateTowerDataViews()
    {
        //TowerDataViews
        for (int i = 0; i < 4; i++)
        {
            GameObject TowerData = UIManager.Instance.CreateTowerUIText("UIText", i);
            TowerData.transform.SetParent(gameObject.transform);
            TowerData.GetComponent<UIText>().SettingUIData(i);
            TowerDataViews.Add(TowerData);
        }
    }

    public void CreateTowerButton()
    {
        {
            Vector3 Pos = new Vector3(-38.0f, -26.0f, 0.0f);
            Vector2 Size = new Vector2(50.0f, 20.0f);
            GameObject TowerButton = UIManager.Instance.CreateButton("Upgrade");
            TowerButton.transform.SetParent(gameObject.transform);
            TowerButton.GetComponent<UIButton>().SetButtonPos(Pos);
            TowerButton.GetComponent<UIButton>().SetButtonSize(Size);
            TowerButton.GetComponent<UIButton>().SetBtnText("Upgrade");
            TowerButton.GetComponent<UIButton>().AddOnClickEventFunction(EButtonType.Upgrade);

            UpgradeBtn = TowerButton;
        }

        {
            Vector3 Pos = new Vector3(-16.0f, -26.0f, 0.0f);
            Vector2 Size = new Vector2(50.0f, 20.0f);
            GameObject TowerButton = UIManager.Instance.CreateButton("Sell");
            TowerButton.transform.SetParent(gameObject.transform);
            TowerButton.GetComponent<UIButton>().SetButtonPos(Pos);
            TowerButton.GetComponent<UIButton>().SetButtonSize(Size);
            TowerButton.GetComponent<UIButton>().SetBtnText("Sell");
            TowerButton.GetComponent<UIButton>().AddOnClickEventFunction(EButtonType.Sell);

            SellBtn = TowerButton;
        }
    }

    /// <summary>
    /// 선택한 Tower 정보 출력.
    /// </summary>
    /// <param name="_Tower">Select Tower</param>
    public void OnTowerData(Transform _Tower)
    {
        SelectTower = _Tower.GetComponent<Tower>();

        gameObject.SetActive(true);

        UpgradeBtn.GetComponent<UIButton>().Set_Btn_Tower(SelectTower);
        SellBtn.GetComponent<UIButton>().Set_Btn_Tower(SelectTower);

        TowerImage.GetComponent<UIImage>().SetImageTransform(SelectTower.TowerSprite);

        TowerDataViews[0].GetComponent<UIText>().UpdateUIText($"Damage : {SelectTower.TowerDamage}");
        TowerDataViews[1].GetComponent<UIText>().UpdateUIText($"Rate : {SelectTower.TowerRate}");
        TowerDataViews[2].GetComponent<UIText>().UpdateUIText($"Range : {SelectTower.TowerRange}");
        TowerDataViews[3].GetComponent<UIText>().UpdateUIText($"Level : {SelectTower.TowerLevel}");

        SelectTower.OnRange();
    }

    public void OffTowerData()
    {
        if (null != SelectTower)
        {
            SelectTower.OffRange();
        }
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
