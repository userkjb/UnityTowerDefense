using System.Collections;
using UnityEngine;
using static ObjectEnum;

public class Tower : MonoBehaviour
{
    private ETowerState TowerStatus = ETowerState.None;
    private GameObject goBullet;
    [SerializeField]
    private Transform BulletSpawnPosition; // 총알 발사 위치.
    private Transform AttackTarget = null;
    [SerializeField]
    private float AttackSpeed = 0.5f; // 발사 딜레이
    [SerializeField]
    private float AttackRange = 2.0f; // 타워 공격 범위
    private float AttackTime = 0.0f; // 코루틴 대용 시간.
    private int AttackDamage = 1; // 타워 공격력
    private int Level = 0;

    public float TowerDamage => AttackDamage;
    public float TowerRate => AttackSpeed;
    public float TowerRange => AttackRange;
    public int TowerLevel => Level + 1;

    private void Awake()
    {
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.AddComponent<BoxCollider>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetSprite("Tower01_Lv01");

        goBullet = ResourcesManager.Instance.GetPrefab("Bullet");
        if(goBullet == null)
        {
            Debug.LogError("Bullet Prefab Is Null");
            return;
        }

        ChangeTowerState(ETowerState.SearchTarget);
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackTarget != null)
        {
            RotateToTarget();
        }
    }
    
    public void ChangeTowerState(ETowerState _State)
    {
        StopCoroutine(_State.ToString());
        TowerStatus = _State;
        StartCoroutine(_State.ToString());
    }

    private void RotateToTarget()
    {
        float dx = AttackTarget.position.x - this.transform.position.x;
        float dy = AttackTarget.position.y - this.transform.position.y;

        float Degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, Degree);
    }


    private IEnumerator SearchTarget()
    {
        while(true)
        {
            // 가까운 적을 찾기위해 큰값을 저장.
            float CloseDis = Mathf.Infinity;

            int EnemyCount = ObjectManager.Instance.GetEnemys().Count;
            for (int i = 0; i < EnemyCount; i++)
            {
                // 모든 적과의 거리 구하기.
                float CurDis = Vector3.Distance(ObjectManager.Instance.GetEnemys()[i].transform.position, this.transform.position);

                // 거리와 범위에 따른.
                if (CurDis <= AttackRange && CurDis <= CloseDis)
                {
                    CloseDis = CurDis;
                    AttackTarget = ObjectManager.Instance.GetEnemys()[i].transform;
                }
            }

            if (AttackTarget != null)
            {
                ChangeTowerState(ETowerState.Attack);
            }

            yield return null;
        }
    }

    private IEnumerator Attack()
    {
        AttackTime += Time.deltaTime;
        while (true)
        {
            if (AttackTarget == null)
            {
                ChangeTowerState(ETowerState.SearchTarget);
                break;
            }

            float Dis = Vector3.Distance(AttackTarget.position, this.transform.position);
            if(Dis > AttackRange)
            {
                AttackTarget = null;
                ChangeTowerState(ETowerState.SearchTarget);
                break;
            }

            //yield return new WaitForSeconds(AttackSpeed);
            if(AttackTime >= AttackSpeed)
            {
                AttackTime = 0.0f;
                SpawnBulletFun(AttackTarget);
            }
            yield return null;
        }
    }

    private void SpawnBulletFun(Transform _AttackTarget)
    {
        if (goBullet == null)
        {
            Debug.LogError("Bullet Prefab Is Null");
            return;
        }

        if(_AttackTarget == null)
        {
            Debug.Log("Attack Target Is Null");
        }


        //Transform ChildTransform = transform.GetChild(0);
        //GameObject CreateBullet = ObjectManager.Instance.SpawnBullet(goBullet, ChildTransform.position);
        GameObject CreateBullet = ObjectManager.Instance.SpawnBullet(goBullet, this.BulletSpawnPosition.position);
        CreateBullet.GetComponent<Bullet>().BulletSetUp(_AttackTarget, AttackDamage);
    }

    public ETowerState GetTowerState()
    {
        return TowerStatus;
    }
}
