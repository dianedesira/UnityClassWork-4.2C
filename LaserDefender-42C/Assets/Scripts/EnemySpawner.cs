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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
