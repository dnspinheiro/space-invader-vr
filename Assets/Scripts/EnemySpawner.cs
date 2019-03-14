using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private float frequency = 1;
    private float timeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(!HUDPlayer.GameOver() && timeCount >= frequency)
        {
            timeCount = 0;
            int index = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[index], transform);
        }
    }
}
