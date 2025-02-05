using UnityEngine;

public class TileWall : MonoBehaviour
{
    public bool IsTower { set; get; }

    private void Awake()
    {
        IsTower = false;
    }
}
