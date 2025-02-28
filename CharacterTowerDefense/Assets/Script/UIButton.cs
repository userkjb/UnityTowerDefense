using UnityEngine;
using UnityEngine.UI;
using static ObjectEnum;

public class UIButton : MonoBehaviour
{
    private RectTransform Rec = null;
    private UIText BtnInText = null;

    private void Awake()
    {
        Rec = gameObject.AddComponent<RectTransform>();
        gameObject.AddComponent<CanvasRenderer>();
        gameObject.AddComponent<Image>();
        gameObject.AddComponent<Button>();
    }

    public void SetButtonPos(Vector3 _Pos)
    {
        Rec.anchoredPosition3D = _Pos;
    }

    public void SetButtonSize(Vector2 _Size)
    {
        Rec.sizeDelta = _Size;
        BtnInText.SetUITextSize(_Size);
    }

    public void SetBtnInTextUI(UIText _Text)
    {
        if(BtnInText == null && _Text != null)
        {
            BtnInText = _Text;
        }

        // 부모 설정.
        BtnInText.GetComponent<RectTransform>().SetParent(gameObject.transform);
    }

    public void SetBtnText(string _Data)
    {
        if(BtnInText == null)
        {
            Debug.LogError("In Btn Text is Null");
            return;
        }

        BtnInText.BtnText(_Data);
    }

    public void AddOnClickEventFunction(EButtonType _Type)
    {
        switch (_Type)
        {
            case EButtonType.Upgrade:
                {
                    GetComponent<Button>().onClick.AddListener(UpgradeCallBack);
                    break;
                }
            case EButtonType.Sell:
                {
                    GetComponent<Button>().onClick.AddListener(SellCallBack);
                    break;
                }
            default:
                break;
        }
    }


    private void UpgradeCallBack()
    {
        Debug.Log("Upgrade");
    }

    private void SellCallBack()
    {
        Debug.Log("Sell");
    }
}
