using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Movement2D Movement = null;
    private Transform Target = null;

    private void Awake()
    {
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.AddComponent<CircleCollider2D>();
        gameObject.AddComponent<Rigidbody2D>();
        Movement = gameObject.AddComponent<Movement2D>();
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

    public void BulletSetUp(Transform _Target)
    {
        if (this.Target == null)
        {
            this.Target = _Target;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Target != null)
        {
            Vector2 Dir = (Target.position - this.transform.position).normalized;
            if(Movement == null)
            {
                return;
            }
            Movement.SetMoveDir(Dir);
        }
        else if(this.Target == null)
        {
            Destroy(gameObject);
        }
    }

    // Collosion 호출 함수.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }

        if(collision.transform != Target)
        {
            return;
        }

        collision.GetComponent<Enemy>().OnDie(); // 대미지가 있으면 이 부분 수정 필요.
        Destroy(gameObject);
    }
}
