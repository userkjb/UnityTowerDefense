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

    public void SetImageTransform(Sprite _Img = null)
    {
        // 이미지 설정.
        if(null != _Img)
        {
            //Sprite Str = ResourcesManager.Instance.GetSprite("Tower01_Lv01");
            //Img.sprite = Str;
            GetComponent<Image>().sprite = _Img;
        }

        // 이미지 사이즈 설정.
        Rt.sizeDelta = new Vector2(50.0f, 50.0f);

        // 이미지 위치 설정.
        Rt.anchoredPosition3D = new Vector3(-38.0f, 15.0f, 0.0f);
    }
}
