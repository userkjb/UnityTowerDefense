using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSpawner : MonoBehaviour
{
    private Camera MainCamera = null;
    private Ray RayValue = new Ray();
    private RaycastHit hit;
    [SerializeField]
    private int SpawnTowerGold = 50;

    private void Awake()
    {
        MainCamera = Camera.main;
    }

    void OnClick(InputValue _Val)
    {
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
                            Debug.Log("Is Tile");
                            TileWall TileTower = hit.transform.GetComponent<TileWall>();

                            if(TileTower.IsTower == false)
                            {
                                GameObject PlayerStats = ObjectManager.Instance.GetPlayerStats();
                                int CurGold = PlayerStats.GetComponent<PlayerGold>().GetPlayerGold();
                                if (CurGold < SpawnTowerGold)
                                {
                                    Debug.Log("I'm running out of Gold.");
                                    return;
                                }
                                else
                                {
                                    PlayerStats.GetComponent<PlayerGold>().SubtractPlayerGold(SpawnTowerGold);
                                }

                                Vector3 TowerPos = hit.transform.position;
                                TowerPos += Vector3.back;
                                ObjectManager.Instance.SpawnTower(TowerPos);
                                TileTower.IsTower = true;
                            }
                        }
                        else if(hit.transform.CompareTag("Tower"))
                        {
                            Debug.Log("Is Tower");
                            Canvas MainCanvas = UIManager.Instance.GetCanvas();
                            if(null == MainCanvas)
                            {
                                Debug.LogError("MainCanvas Is Null");
                                return;
                            }

                            TowerPanel TowerPan = MainCanvas.transform.GetChild(2).GetComponent<TowerPanel>();
                            TowerPan.OnTowerData();
                        }
                        else
                        {
                            Debug.Log("What Is this???");
                        }
                    }
                    else
                    {
                        // ºó °ø°£.
                        GameObject go = UIManager.Instance.GetTowerUI("TowerPanel");
                        TowerPanel TowerPanel = go.GetComponent<TowerPanel>();
                        if (false == TowerPanel.GetActive())
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
