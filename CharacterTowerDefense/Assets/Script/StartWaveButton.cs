using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class StartWaveButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.GetComponent<Button>().onClick.AddListener(delegate() { StartButtonCallback(); });
        //gameObject.GetComponent<Button>().onClick.AddListener(StartButtonCallback);
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { StartButtonCallback(); });
    }

    private void StartButtonCallback()
    {
        GameObject EnemySpawnerPrefab = ObjectManager.Instance.GetEnemySpawner();
        if(EnemySpawnerPrefab != null)
        {
            WaveSystem WaveSys = EnemySpawnerPrefab.GetComponent<WaveSystem>();
            WaveSys.Button_StartWave();
        }
    }
}
