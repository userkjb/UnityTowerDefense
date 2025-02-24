using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    private RectTransform Rec = null;
    private UIText BtnInText = null;

    private void Awake()
    {
        gameObject.AddComponent<RectTransform>();
        gameObject.AddComponent<CanvasRenderer>();
        gameObject.AddComponent<Image>();
        gameObject.AddComponent<Button>();

        Rec = gameObject.GetComponent<RectTransform>();
    }

    public void SetButtonPos(Vector3 _Pos)
    {
        Rec.anchoredPosition3D = _Pos;
    }

    public void SetButtonSize(Vector2 _Size)
    {
        Rec.sizeDelta = _Size;
    }

    public void SetBtnInTextUI(UIText _Text)
    {
        if(BtnInText == null && _Text != null)
        {
            BtnInText = _Text;
        }

        BtnInText.GetComponent<RectTransform>().SetParent(gameObject.transform);
    }
}
