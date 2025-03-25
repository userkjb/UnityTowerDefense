using UnityEngine;
using static ObjectEnum;

public class MainCanvas : MonoBehaviour
{
    private void Awake()
    {
        GameObject go = gameObject;
        UIManager.Instance.AddCanvas(go);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreatePanel();
    }


    private void CreatePanel()
    {
        // TowerPanel
        {
            GameObject TowerPanel = UIManager.Instance.CreatePanel("TowerPanel");

            TowerPanel.transform.SetParent(gameObject.transform);
        }

        // Select Tower Panel
        {
            GameObject SelectTower = UIManager.Instance.CreatePanel("SelectTowerPanel");

            SelectTower.transform.SetParent(gameObject.transform);
        }
    }
}
