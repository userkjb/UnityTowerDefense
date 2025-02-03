using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> EnemySprites = new List<Sprite>();


    void Start()
    {
        EnemySpriteLoad();

        if (EnemySprites.Count == 0)
        {
            Debug.LogError("Enemy Sprite Is Null");
        }
        
        // Component Setting
        // Transform
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Sprite Renderer
        gameObject.GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpriteLoad()
    {
        for (int i = 1; i <= 5; i++)
        {
            Sprite Re = ResourcesManager.Instance.Load<Sprite>($"Sprites/Enemy0{i}");


        }
        
    }
}
