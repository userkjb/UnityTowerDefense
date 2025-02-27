using System.Collections;
using UnityEngine;
using static ObjectEnum;

/// <summary>
/// Enemy의 HP를 관리하는 Script
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
    // 현재 실행중인 코루틴
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
        // 죽었다면,
        if(false == Life)
        {
            return;
        }

        // 살아있다면,
        CurrentHP -= _Damage;

        // 코루틴 컨트롤
        if(CurrentCoroutine == null)
        {
            CurrentCoroutine = StartCoroutine("HitAnimation");
        }
        else if(CurrentCoroutine != null)
        {
            // 어떤 코루틴이 실행되고 있다.

            if(CurrentCoroutine.ToString() == "HitAnimation")
            {
                StopCoroutine("HitAnimation");
                CurrentCoroutine = StartCoroutine("HitAnimation");
            }
        }


        // 계산 결과.
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
