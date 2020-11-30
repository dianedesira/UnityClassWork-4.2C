using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;

    int startingWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        WaveConfig currentWave = waveConfigs[startingWave];

        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            GameObject enemyClone = Instantiate(waveConfig.GetEnemyPrefab(), 
                                                waveConfig.GetWaypoints()[0].position, 
                                                Quaternion.identity);

            /* A reference to the current generated clone is fetched so that we can set the current wave
             * inside its EnemyPathing component. Then, enemypathing can know from which wave the path
             * should be fetched.
             */
            enemyClone.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
