using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSpawner : MonoBehaviour
{
    private Camera MainCamera = null;
    private Ray RayValue = new Ray();
    private RaycastHit hit;
    //[SerializeField]
    //private int SpawnTowerGold = 50;
    private TowerDataTable TowerDT = null;


    private void Awake()
    {
        MainCamera = Camera.main;
    }

    void OnClick(InputValue _Val)
    {
        if(null == TowerDT)
        {
            TowerDT = DataTableManager.Instance.GetDataTable("TowerDataTable") as TowerDataTable;
        }

        float InputValue = _Val.Get<float>();
        switch (InputValue)
        {
            case 0: // Up
                {
                    break;
                }
            case 1: // Down
                {
                    Vector2 MousePosition = Mouse.current.position.value;
                    
                    RayValue = MainCamera.ScreenPointToRay(MousePosition);
                    if(Physics.Raycast(RayValue, out hit, Mathf.Infinity))
                    {
                        if (hit.transform.CompareTag("Tile"))
                        {
                            TileWall TileTower = hit.transform.GetComponent<TileWall>();

                            if(TileTower.IsTower == false)
                            {
                                GameObject PlayerStats = ObjectManager.Instance.GetPlayerStats();
                                int CurGold = PlayerStats.GetComponent<PlayerGold>().GetPlayerGold();
                                if (CurGold < TowerDT.TowerData[0].Cost)
                                {
                                    Debug.Log("I'm running out of Gold.");
                                    return;
                                }
                                else
                                {
                                    PlayerStats.GetComponent<PlayerGold>().SubtractPlayerGold(TowerDT.TowerData[0].Cost);
                                }

                                Vector3 TowerPos = hit.transform.position;
                                TowerPos += Vector3.back;
                                ObjectManager.Instance.SpawnTower(TowerPos);
                                TileTower.IsTower = true;
                            }
                        }
                        else if(hit.transform.CompareTag("Tower"))
                        {
                            Transform HitTower = hit.transform;
                            if(null == HitTower)
                            {
                                Debug.LogError("Hit Object Tower Is null");
                                return;
                            }

                            Canvas MainCanvas = UIManager.Instance.GetCanvas();
                            if(null == MainCanvas)
                            {
                                Debug.LogError("MainCanvas Is Null");
                                return;
                            }
                            // 이 코드는 조금 위험.
                            TowerPanel TowerPan = MainCanvas.transform.GetChild(2).GetComponent<TowerPanel>();
                            TowerPan.OnTowerData(HitTower);
                        }
                        else
                        {
                            Debug.Log("What Is this???");
                        }
                    }
                    else
                    {
                        // 빈 공간.
                        GameObject go = UIManager.Instance.GetTowerUI("TowerPanel");
                        TowerPanel TowerPanel = go.GetComponent<TowerPanel>();
                        if (false == TowerPanel.IsActive())
                        {
                            return;
                        }
                        TowerPanel.OffTowerData();
                    }
                    break;
                }
            default:
                break;
        }
    }
}
