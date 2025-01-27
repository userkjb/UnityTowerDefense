using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> EnemySprites = new List<Sprite>();


    private Movement2D UseMovement2D;

    void Start()
    {
        if (EnemySprites.Count == 0)
        {
            Debug.LogError("Enemy Sprite Is Null");
        }

        UseMovement2D = GetComponent<Movement2D>();

        //List<GameObject> Waypoints = GameManager.Instance.GetWayPoints();

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
}
