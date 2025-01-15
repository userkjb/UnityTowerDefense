using UnityEngine;

public class Movement2D : MonoBehaviour
{
    /// <summary>
    /// 이동 속도.
    /// </summary>
    [SerializeField]
    private float MoveSpeed = 0.0f;
    /// <summary>
    /// 이동 방향
    /// </summary>
    [SerializeField]
    private Vector3 MoveDir = Vector3.zero;




    private void Update()
    {
        transform.position += MoveSpeed * MoveDir * Time.deltaTime;
    }

    public void SetMoveDir(Vector3 _dir)
    {
        MoveDir = _dir;
    }

    public float GetMoveSpeed()
    {
        return MoveSpeed;
    }
}
