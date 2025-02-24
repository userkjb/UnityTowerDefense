using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static ObjectEnum;

public class UIText : MonoBehaviour
{
    RectTransform Rec = null;
    TextMeshProUGUI TextView = null;
    ETextType TextType = ETextType.None;

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


    public void SetUIPosition(Vector3 _Position)
    {
        Rec.anchoredPosition3D = _Position;
    }

    public void SetUIText(string _Text)
    {
        TextView.text = _Text;
    }
}
