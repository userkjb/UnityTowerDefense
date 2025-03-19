using UnityEngine;
using static ObjectEnum;

public class UITowerConstruction : MonoBehaviour
{
    private SpriteRenderer UIImage = null;

    private void Awake()
    {
        UIImage = gameObject.AddComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!ResourcesManager.Instance.IsResource("UIPanelBackground"))
        {
            ResourcesManager.Instance.Load<Sprite>("Sprites/UIPanelBackground", ResourceType.Sprite);
        }

        UIImage.sprite = ResourcesManager.Instance.GetSprite("UIPanelBackground");

        //gameObject.SetActive(false);
    }


    public void OnTowerConstruction(Vector3 _Pos)
    {
        gameObject.GetComponent<Transform>().position = _Pos;
        gameObject.SetActive(true);
    }

    public void OffTowerConstruction()
    {
        gameObject.SetActive(false);
    }
}
