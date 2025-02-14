using UnityEngine;
using UnityEngine.UI;

public class UIImage : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<RectTransform>();
        gameObject.AddComponent<CanvasRenderer>();
        gameObject.AddComponent<Image>();
    }

    public void SetImageTransform()
    {

    }
}
