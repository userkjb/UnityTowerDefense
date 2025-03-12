using System.Collections;
using UnityEngine;
using static ObjectEnum;
using static TowerDataTable;

public class Tower : MonoBehaviour
{
    private ETowerState TowerStatus = ETowerState.None;
    private TowerDataTable TowerData;
    private GameObject goBullet;
    [SerializeField]
    private Transform BulletSpawnPosition; // �Ѿ� �߻� ��ġ.
    private Transform AttackTarget = null;
    //[SerializeField]
    //private float AttackSpeed = 0.5f; // �߻� ������
    //[SerializeField]
    //private float AttackRange = 2.0f; // Ÿ�� ���� ����
    private float AttackTime = 0.0f; // �ڷ�ƾ ��� �ð�.
    //private float AttackDamage = 1; // Ÿ�� ���ݷ�
    private int Level = 0;

    public Sprite TowerSprite => TowerData.TowerData[Level].Sprite;
    public float TowerDamage => TowerData.TowerData[Level].Damage;
    public float TowerRate => TowerData.TowerData[Level].Rate;
    public float TowerRange => TowerData.TowerData[Level].Range;
    public int TowerLevel => Level + 1;

    private void Awake()
    {
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.AddComponent<BoxCollider>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScriptableObject so = DataTableManager.Instance.GetDataTable("TowerDataTable");
        TowerData = so as TowerDataTable;

        gameObject.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //gameObject.GetComponent<SpriteRenderer>().sprite = ResourcesManager.Instance.GetSprite("Tower01_Lv01");
        gameObject.GetComponent<SpriteRenderer>().sprite = TowerData.TowerData[Level].Sprite;

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
            // ����� ���� ã������ ū���� ����.
            float CloseDis = Mathf.Infinity;

            int EnemyCount = ObjectManager.Instance.GetEnemys().Count;
            for (int i = 0; i < EnemyCount; i++)
            {
                // ��� ������ �Ÿ� ���ϱ�.
                float CurDis = Vector3.Distance(ObjectManager.Instance.GetEnemys()[i].transform.position, this.transform.position);

                // �Ÿ��� ������ ����.
                if (CurDis <= TowerData.TowerData[Level].Range && CurDis <= CloseDis)
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
            if(Dis > TowerData.TowerData[Level].Range)
            {
                AttackTarget = null;
                ChangeTowerState(ETowerState.SearchTarget);
                break;
            }

            //yield return new WaitForSeconds(AttackSpeed);
            if(AttackTime >= TowerData.TowerData[Level].Rate)
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
        CreateBullet.GetComponent<Bullet>().BulletSetUp(_AttackTarget, TowerData.TowerData[Level].Damage);
    }



    public void TowerUpgrade()
    {
        PlayerGold PlayerGold = ObjectManager.Instance.GetPlayerStats().GetComponent<PlayerGold>();

        int PlayerGoldValue = PlayerGold.GetPlayerGold(); // ���� ������ �ִ� ���.
        int TowerUpgradeGold = TowerData.TowerData[Level + 1].Cost; // ���׷��̵忡 �ʿ��� ���.

        if(PlayerGoldValue >= TowerUpgradeGold)
        {
            // ��� ���� ���ְ�.
            PlayerGold.SubtractPlayerGold(TowerUpgradeGold);

            Level++;
            gameObject.GetComponent<SpriteRenderer>().sprite = TowerData.TowerData[Level].Sprite;
        }

        // UI Image ����ȭ.
        Transform TowerImageWidget = UIManager.Instance.GetTowerUI("TowerPanel").transform.GetChild(0);
        TowerImageWidget.GetComponent<UIImage>().SetImageTransform(TowerData.TowerData[Level].Sprite);
    }

    public void TowerSell()
    {
        Debug.Log("Sell!!!!!");
    }
}
