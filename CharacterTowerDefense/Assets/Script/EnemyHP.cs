using System.Collections;
using UnityEngine;
using static ObjectEnum;

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
    
    public void SetEnemyHP(int _WaveValue)
    {
        switch(_WaveValue)
        {
            case 1:
                {
                    MaxHP = 5;
                    break;
                }
            case 2:
                {
                    MaxHP = 10;
                    break;
                }
            case 3:
                {
                    MaxHP = 10;
                    break;
                }
            case 4:
                {
                    MaxHP = 20;
                    break;
                }
            case 5:
                {
                    MaxHP = 100;
                    break;
                }
            default:
                CurrentHP = MaxHP;
                break;

        }
        CurrentHP = MaxHP;
    }


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

    public void TackDamage(float _Damage)
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
                Enemy.OnDie(EDestroyType.Kill);
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
