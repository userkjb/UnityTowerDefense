using NUnit.Framework;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {        
        // Component Setting
        // Transform
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Sprite Renderer
        //gameObject.GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetEnemyNumber("Enemy01");
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
