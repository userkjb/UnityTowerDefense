using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour
{
    List<GameObject> TowerDataViews= new List<GameObject>();

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
    }

    private void CreateTowerImageView()
    {
        GameObject TowerImage = UIManager.Instance.CreateUIImage("UIImage");
        TowerImage.transform.SetParent(gameObject.transform);
    }

    private void CreateTowerDataViews()
    {
        //TowerDataViews
        for (int i = 0; i < 4; i++)
        {
            //GameObject TowerData = 
        }
    }
}
