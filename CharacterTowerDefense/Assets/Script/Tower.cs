using System.Collections;
using UnityEngine;
using static ObjectEnum;

public class Tower : MonoBehaviour
{
    private ETowerState TowerStatus = ETowerState.None;
    private GameObject Bullet;
    [SerializeField]
    private Transform BulletSpawnPosition;
    [SerializeField]
    private float AttackSpeed = 0.5f;
    [SerializeField]
    private float AttackRange = 2.0f;
    private float AttackTime = 0.0f;
    private Transform AttackTarget = null;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.AddComponent<SpriteRenderer>();
        
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetSprite("Tower01_Lv01");

        Bullet = ResourcesManager.Instance.GetPrefab("Bullet");
        if(Bullet == null)
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
            // ����� ���� ã������ ū���� ����.
            float CloseDis = Mathf.Infinity;

            int EnemyCount = ObjectManager.Instance.GetEnemys().Count;
            for (int i = 0; i < EnemyCount; i++)
            {
                // ��� ������ �Ÿ� ���ϱ�.
                float CurDis = Vector3.Distance(ObjectManager.Instance.GetEnemys()[i].transform.position, this.transform.position);

                // �Ÿ��� ������ ����.
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
                SpawnBulletFun();
            }
            yield return null;
        }
    }

    private void SpawnBulletFun()
    {
        if (Bullet == null)
        {
            Debug.LogError("Bullet Prefab Is Null");
            return;
        }
        ObjectManager.Instance.SpawnBullet(Bullet, this.BulletSpawnPosition.position);
    }
}
