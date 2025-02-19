using UnityEngine;
using UnityEngine.UI;

public class UIImage : MonoBehaviour
{
    private RectTransform Rt = null;
    private CanvasRenderer CRenderer = null;
    private Image Img = null;

    private void Awake()
    {
        Rt = gameObject.AddComponent<RectTransform>();
        CRenderer = gameObject.AddComponent<CanvasRenderer>();
        Img = gameObject.AddComponent<Image>();
    }

    public void SetImageTransform()
    {
        // �̹��� ����.
        Sprite Str = ResourcesManager.Instance.GetSprite("Tower01_Lv01");
        //GetComponent<Image>().sprite = Str;
        Img.sprite = Str;

        // �̹��� ������ ����.
        //RectTransform Rec = GetComponent<RectTransform>();
        //Rec.sizeDelta = new Vector2(50.0f, 50.0f);
        Rt.sizeDelta = new Vector2(50.0f, 50.0f);

        // �̹��� ��ġ ����.
        Rt.anchoredPosition3D = new Vector3(-38.0f, 15.0f, 0.0f);
    }
}
