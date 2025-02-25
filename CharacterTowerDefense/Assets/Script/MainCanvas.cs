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
        GameObject TowerPanel = UIManager.Instance.CreatePanel("TowerPanel");

        TowerPanel.transform.SetParent(gameObject.transform);
    }
}
