using UnityEngine;
using static ObjectEnum;

public class UITowerAttackRange : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<SpriteRenderer>();

        if (!ResourcesManager.Instance.IsResource("TowerAttackRange"))
        {
            //ResourcesManager.Instance.Load<Sprite>("Sprites/TowerAttackRange", ResourceType.Tower);
            ResourcesManager.Instance.Load<Sprite>("Sprites/TowerAttackRange", ResourceType.Sprite);
        }
    }

    public void SetComponent()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetSprite("TowerAttackRange");
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        gameObject.GetComponent<Transform>().position = Vector3.zero;
    }

    public void SetComponent(Vector3 _Pos, float _Range)
    {
        gameObject.GetComponent<Transform>().position = _Pos;

        float Value = _Range * 2.0f;
        transform.localScale = Vector3.one * Value;
    }

    public void OnTowerAttackRange()
    {
        if(gameObject.activeSelf == false)
            gameObject.SetActive(true);
    }

    public void OffTowerAttackRange()
    {
        if (gameObject.activeSelf == true)
            gameObject.SetActive(false);
    }
}
