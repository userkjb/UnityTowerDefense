using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Movement2D movement2D = null;
    private int WaypointCount = 0;
    private int CurrentIndex = 0;
    private int RotateSpeed = 10;

    void Start()
    {        
        // Component Setting
        // Transform
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Sprite Renderer
        //gameObject.GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetEnemySprite("Enemy01");
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySetting()
    {
        movement2D = GetComponent<Movement2D>();

        WaypointCount = ObjectManager.Instance.GetWayPoints().Count;

        this.transform.position = ObjectManager.Instance.GetWayPoints()[WaypointCount].transform.position;

        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        NextMoveDirection();

        while (true)
        {
            // È¸Àü.
            this.transform.Rotate(Vector3.forward * RotateSpeed);

            if(Vector3.Distance(this.transform.position, ObjectManager.Instance.GetWayPoints()[WaypointCount].transform.position) < 0.02f * movement2D.GetMoveSpeed())
            {
                NextMoveDirection();
            }

            yield return null;
        }
    }

    private void NextMoveDirection()
    {
        if (CurrentIndex < WaypointCount)
        {
            this.transform.position = ObjectManager.Instance.GetWayPoints()[CurrentIndex].transform.position;
            CurrentIndex++;

            Vector3 Dir = (ObjectManager.Instance.GetWayPoints()[CurrentIndex].transform.position - this.transform.position).normalized;
            movement2D.SetMoveDir(Dir);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
