using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave spawner data")]
public class EnemyWaveSpawnerData : ScriptableObject
{
    public List<EnemyWaveData> waves;
    /// <summary>
    /// time between switching waves in seconds
    /// </summary>
    public int timeBetweenWaves;
}
