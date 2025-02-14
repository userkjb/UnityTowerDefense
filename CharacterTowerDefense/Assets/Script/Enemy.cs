using NUnit.Framework;
using System.Collections;
using UnityEngine;
using static ObjectEnum;

public class Enemy : MonoBehaviour
{
    private Movement2D movement2D = null;
    private EnemyHP EnemyHp = null;
    private int WaypointCount = 0;
    private int CurrentIndex = 0;
    private int RotateSpeed = 10;

    [SerializeField]
    private int DropGold = 10;

    private void Awake()
    {
        gameObject.AddComponent<CircleCollider2D>();
        gameObject.AddComponent<EnemyHP>();
    }

    void Start()
    {
        if(EnemyHp == null)
        {
            EnemyHp = GetComponent<EnemyHP>();
        }

        // Component Setting
        // Transform
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Sprite Renderer
        //gameObject.GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
        //gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetSprite("Enemy01");
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySetting(int _WaveCount)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetSprite($"Enemy0{_WaveCount}");
        if(EnemyHp == null)
        {
            EnemyHp = GetComponent<EnemyHP>();
            EnemyHp.SetEnemyHP(_WaveCount);
        }
        else
        {
            EnemyHp.SetEnemyHP(_WaveCount);
        }

            movement2D = GetComponent<Movement2D>();
        if (movement2D == null)
        {
            Debug.LogError("Movement2D Is Null");
            return;
        }
        SettingMoveSpeedGold(_WaveCount);

        WaypointCount = ObjectManager.Instance.GetWayPoints().Count;

        // 생성 위치 설정.
        this.transform.position = ObjectManager.Instance.GetWayPoints()[CurrentIndex].transform.position;

        StartCoroutine("OnMove");
    }

    private void SettingMoveSpeedGold(int _WaveCount)
    {
        if(movement2D == null)
        {
            Debug.LogError("Enemy Is Not Movement2D Component");
            return;
        }
        float Speed = 0.0f;
        switch (_WaveCount)
        {
            case 1:
                {
                    Speed = 1.0f;
                    DropGold = 10;
                    break;
                }
            case 2:
                {
                    Speed = 1.5f;
                    DropGold = 15;
                    break;
                }
            case 3:
                {
                    Speed = 2.0f;
                    DropGold = 50;
                    break;
                }
            case 4:
                {
                    Speed = 3.0f;
                    DropGold = 20;
                    break;
                }
            case 5:
                {
                    Speed = 1.5f;
                    DropGold = 50;
                    break;
                }
            default:
                break;

        }
        movement2D.SetMoveSpeed(Speed);
    }

    private IEnumerator OnMove()
    {
        NextMoveDirection();

        while (true)
        {
            // 회전.
            this.transform.Rotate(Vector3.forward * RotateSpeed);

            if(Vector3.Distance(this.transform.position, ObjectManager.Instance.GetWayPoints()[CurrentIndex].transform.position) < 0.02f * movement2D.GetMoveSpeed())
            {
                NextMoveDirection();
            }

            yield return null;
        }
    }

    private void NextMoveDirection()
    {
        if (CurrentIndex < WaypointCount-1)
        {
            this.transform.position = ObjectManager.Instance.GetWayPoints()[CurrentIndex].transform.position;
            CurrentIndex++;

            Vector3 Dir = (ObjectManager.Instance.GetWayPoints()[CurrentIndex].transform.position - this.transform.position).normalized;
            movement2D.SetMoveDir(Dir);
        }
        else
        {
            // 다음 Waypoint가 없다. = 도착지점.
            DropGold = 0;
            OnDie(EDestroyType.Arrive);
        }
    }

    public void OnDie(EDestroyType _EDestroyType)
    {
        ObjectManager.Instance.DestroyEnemy(this, _EDestroyType, DropGold);
    }
}
