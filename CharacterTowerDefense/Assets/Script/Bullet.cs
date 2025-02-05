using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.AddComponent<CircleCollider2D>();
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.AddComponent<Movement2D>();
    }

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetSprite("Projectile01");
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        gameObject.GetComponent<Movement2D>().SetMoveSpeed(5.0f);

        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        gameObject.GetComponent<CircleCollider2D>().radius = 0.06f;

        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
