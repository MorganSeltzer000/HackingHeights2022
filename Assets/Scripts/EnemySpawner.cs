using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public float[] xRange = new float[2];
    public float[] yRange = new float[2];

    public List<Enemy> enemyPrefabs;

    public int enemiesPerWaveMax;
    public float timeBetweenWaves;

    int numOfEnemyTypes;

    public bool SpawnerEnabled;

    // Start is called before the first frame update
    void Start()
    {
        numOfEnemyTypes = enemyPrefabs.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        while (SpawnerEnabled)
        {
            SpawnRandom();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnRandom()
    {
        int enemiesToSpawn = Random.Range(0, enemiesPerWaveMax + 1);
        for (int i = 0; i < enemiesToSpawn; i++)
        {

        }

    }
}
