using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemySpawnPoint;


    // Get/Set
    public GameObject GetEnemySpawnPoint()
    {
        return EnemySpawnPoint;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (EnemySpawnPoint == null)
        {
            Debug.LogError("Enemy Spawn Point Is Null");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
