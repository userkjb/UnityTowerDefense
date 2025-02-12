using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float MaxHP = 20.0f;
    private float CurrentHP = 0.0f;


    private void Awake()
    {
        CurrentHP = MaxHP;
    }

    public void TakeDamage(float _Damage)
    {
        CurrentHP -= _Damage;

        if(CurrentHP <= 0.0f)
        {
            Debug.Log("ÃßÈÄ ÄÁÅÙÃ÷ Ãß°¡.");
        }
    }

    public float GetPlayerHP()
    {
        return CurrentHP;
    }

    public float GetPlayerHPMax()
    {
        return MaxHP;
    }
}
