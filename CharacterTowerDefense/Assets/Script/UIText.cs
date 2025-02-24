using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static ObjectEnum;

public class UIText : MonoBehaviour
{
    private RectTransform Rec = null;
    private TextMeshProUGUI TextView = null;
    private ETextType TextType = ETextType.None;

    private void Awake()
    {
        gameObject.AddComponent<RectTransform>();
        gameObject.AddComponent<CanvasRenderer>();
        TextView = gameObject.AddComponent<TextMeshProUGUI>();
        Rec = gameObject.GetComponent<RectTransform>();
    }

    public void SettingUIData(int _Index)
    {
        TextView.fontSize = 18.0f;

        float Start_Y_Position = 14.0f;

        float Calculate = Start_Y_Position - (_Index * TextView.fontSize);
        Rec.anchoredPosition3D = new Vector3(35.0f, Calculate, 0.0f);

        TextView.text = "Damage : 000";

        switch(_Index)
        {
            case 0:
                {
                    TextType = ETextType.Damage;
                    break;
                }
            case 1:
                {
                    TextType = ETextType.Rate;
                    break;
                }
            case 2:
                {
                    TextType = ETextType.Range;
                    break;
                }
            case 3:
                {
                    TextType = ETextType.Level;
                    break;
                }
            default:
                break;
        }
    }

    public void UpdateUIText(string _ValueText)
    {
        TextView.text = _ValueText;
    }

    public void SetUITextSize(Vector2 _Size)
    {
        Rec.sizeDelta = _Size;
    }

    public void BtnText(string _ValueText)
    {
        TextView.text = _ValueText;
        TextView.fontStyle = FontStyles.Bold;
        TextView.fontSize = 10.0f;
        TextView.color = Color.black;
        TextView.alignment = TextAlignmentOptions.Center;
    }
}
