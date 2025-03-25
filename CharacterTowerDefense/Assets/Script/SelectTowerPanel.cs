using UnityEngine;

/// <summary>
/// Select Tower Construction Panel.
/// </summary>
public class SelectTowerPanel : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<RectTransform>().position = Vector3.zero;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetPosition(Vector3 _Pos)
    {
        // ¿ùµå ÁÂÇ¥ -> Äµ¹ö½º ÁÂÇ¥ º¯È¯.
        Vector2 ScreenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, _Pos);

        gameObject.GetComponent<RectTransform>().position = ScreenPosition;
    }


    public void OnSelectTower()
    {
        gameObject.SetActive(true);
    }

    public void OffSelectTower()
    {
        gameObject.SetActive(false);
    }
}
