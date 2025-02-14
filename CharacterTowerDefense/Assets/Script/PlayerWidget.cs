using TMPro;
using UnityEngine;

public class PlayerWidget : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI PlayerHPText;
    [SerializeField]
    private TextMeshProUGUI PlayerGoldText;
    [SerializeField]
    private TextMeshProUGUI PlayerWaveText;

    private GameObject goPlayerStats = null;

    private void Start()
    {
        goPlayerStats = ObjectManager.Instance.GetPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        // HP
        {
            if (goPlayerStats == null)
            {
                goPlayerStats = ObjectManager.Instance.GetPlayerStats();
            }

            if (goPlayerStats != null)
            {
                PlayerHP Playerhp = null;
                Playerhp = ObjectManager.Instance.GetPlayerStats().GetComponent<PlayerHP>();
                PlayerHPText.text = Playerhp.GetPlayerHP().ToString() + "/" + Playerhp.GetPlayerHPMax().ToString();
            }
        }

        // Gold
        {
            if (goPlayerStats == null)
            {
                goPlayerStats = ObjectManager.Instance.GetPlayerStats();
            }

            if (goPlayerStats != null)
            {
                PlayerGold PlayerGoldValue = null;
                PlayerGoldValue = ObjectManager.Instance.GetPlayerStats().GetComponent<PlayerGold>();
                PlayerGoldText.text = PlayerGoldValue.GetPlayerGold().ToString();
            }
        }

        // Wave
        {
            if(PlayerWaveText != null)
            {
                GameObject go = ObjectManager.Instance.GetEnemySpawner();
                int OutputText = go.GetComponent<WaveSystem>().GetWaveValue();
                PlayerWaveText.text = OutputText.ToString();
            }
        }
    }
}
