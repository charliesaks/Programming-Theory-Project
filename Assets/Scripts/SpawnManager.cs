using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float minSpawnTime = 1.0f;
    [SerializeField] float maxSpawnTime = 4.0f;

    private float startZ = 40.0f;
    private float rangeX = 60.0f;
    private float posY = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int idx = Random.Range(0, enemyPrefabs.Length);
            float posX = Random.Range(-rangeX, rangeX);
            Vector3 position = new Vector3(posX, posY, startZ);
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            Instantiate(enemyPrefabs[idx], position, enemyPrefabs[idx].transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
