using UnityEngine;

public class StartPoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObjectManager.Instance.SpawnEnemySpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
