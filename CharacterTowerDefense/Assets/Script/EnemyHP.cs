using System.Collections;
using UnityEngine;

/// <summary>
/// Enemy�� HP�� �����ϴ� Script
/// </summary>
public class EnemyHP : MonoBehaviour
{
    private bool Life = true;
    [SerializeField]
    private float MaxHP = 5.0f;
    private float CurrentHP = 0.0f;
    //private float AnimationTime = 0.0f;
    private Enemy Enemy = null;
    private SpriteRenderer SpriteRenderer = null;
    // ���� �������� �ڷ�ƾ
    private Coroutine CurrentCoroutine = null;
    

    private void Awake()
    {
        CurrentHP = MaxHP;
        Enemy = GetComponent<Enemy>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsDie()
    {
        if (Life == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void TackDamage(int _Damage)
    {
        // �׾��ٸ�,
        if(false == Life)
        {
            return;
        }

        // ����ִٸ�,
        CurrentHP -= _Damage;

        // �ڷ�ƾ ��Ʈ��
        if(CurrentCoroutine == null)
        {
            CurrentCoroutine = StartCoroutine("HitAnimation");
        }
        else if(CurrentCoroutine != null)
        {
            // � �ڷ�ƾ�� ����ǰ� �ִ�.

            if(CurrentCoroutine.ToString() == "HitAnimation")
            {
                StopCoroutine("HitAnimation");
                CurrentCoroutine = StartCoroutine("HitAnimation");
            }
        }


        // ��� ���.
        if(CurrentHP <= 0)
        {
            Life = false;
            if(Enemy != null)
            {
                Enemy.OnDie();
            }
        }
    }

    private IEnumerator HitAnimation()
    {
        if(SpriteRenderer == null)
        {
            Debug.LogError("Sprite Renderer Is Null");
            yield return null;
        }
        Color CurColor = SpriteRenderer.color;
        CurColor.a = 0.5f;
        SpriteRenderer.color = CurColor;

        yield return new WaitForSeconds(0.05f);

        CurColor.a = 1.0f;
        SpriteRenderer.color = CurColor;
    }
}
