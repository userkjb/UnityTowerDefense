using System.Collections;
using UnityEngine;

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
