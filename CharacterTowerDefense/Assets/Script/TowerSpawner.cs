using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TowerSpawner : MonoBehaviour
{
    private bool IsUI = false;
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

    private void Update()
    {
        // UI 체크
        IsUI = EventSystem.current.IsPointerOverGameObject();
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

                    // 타워의 RangeUI를 끈다.
                    TowerRangeUIOff();

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

                                // test
                                {
                                    GameObject go = ObjectManager.Instance.SpawnUI(TowerPos);
                                    go.GetComponent<UITowerConstruction>().OnTowerConstruction(TowerPos);

                                }
                            }
                        }
                        else if(hit.transform.CompareTag("Tower"))
                        {
                            // 클릭된 타워를 가져와서.
                            Transform HitTower = hit.transform;
                            if(null == HitTower)
                            {
                                Debug.LogError("Hit Object Tower Is null");
                                return;
                            }

                            // 캔버스를 불러오고,
                            Canvas MainCanvas = UIManager.Instance.GetCanvas();
                            if(null == MainCanvas)
                            {
                                Debug.LogError("MainCanvas Is Null");
                                return;
                            }

                            // 캔버스의 자식들 중에 TowerPanel에 타워 정보를 넘겨준다.
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
                        if(true == IsUI)
                        {
                            return;
                        }
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

    private void TowerRangeUIOff()
    {
        List<Tower> Towers = ObjectManager.Instance.GetTowers();
        foreach(Tower tower in Towers)
        {
            tower.OffRange();
        }
    }
}
