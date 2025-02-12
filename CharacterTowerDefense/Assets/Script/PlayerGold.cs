using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    [SerializeField]
    private int CurrentGold = 200;


    public int GetPlayerGold()
    {
        return CurrentGold;
    }

    public void AddPlayerGold(int _Value)
    {
        CurrentGold += _Value;
    }

    public void SubtractPlayerGold(int _Value)
    {
        CurrentGold -= _Value;
    }
}
