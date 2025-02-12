using TMPro;
using UnityEngine;

public class PlayerHPWidget : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI PlayerHPText;
    private GameObject goPlayerHP = null;

    private void Start()
    {
        goPlayerHP = ObjectManager.Instance.GetPlayerHP();
    }

    // Update is called once per frame
    void Update()
    {
        if(goPlayerHP == null)
        {
            goPlayerHP = ObjectManager.Instance.GetPlayerHP();
        }

        if(goPlayerHP != null)
        {
            PlayerHP Playerhp = null;
            Playerhp = ObjectManager.Instance.GetPlayerHP().GetComponent<PlayerHP>();
            PlayerHPText.text = Playerhp.GetPlayerHP().ToString() + "/" + Playerhp.GetPlayerHPMax().ToString();
        }
    }
}
