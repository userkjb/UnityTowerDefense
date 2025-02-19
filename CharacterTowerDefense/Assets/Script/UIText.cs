using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    RectTransform Rec = null;
    TextMeshProUGUI TextView = null;

    private void Awake()
    {
        gameObject.AddComponent<RectTransform>();
        gameObject.AddComponent<CanvasRenderer>();
        TextView = gameObject.AddComponent<TextMeshProUGUI>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUIPosition(int _Index)
    {
        Rec = GetComponent<RectTransform>();
        TextView.text = "Damage : 000";
        Rec.anchoredPosition3D = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
