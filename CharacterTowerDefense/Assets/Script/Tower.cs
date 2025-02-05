using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.AddComponent<SpriteRenderer>();
        
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetSprite("Tower01_Lv01");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
