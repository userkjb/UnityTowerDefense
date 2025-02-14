using UnityEngine;
using static ObjectEnum;

public class MainCanvas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject go = gameObject;
        UIManager.Instance.AddCanvas(go);

        CreatePanel();
    }


    private void CreatePanel()
    {
        GameObject TowerPanel = UIManager.Instance.CreatePanel("TowerPanel");

        TowerPanel.transform.SetParent(gameObject.transform);
    }
}
