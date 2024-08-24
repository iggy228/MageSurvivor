using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyWaveData
{
    public List<GameObject> enemiesToSpawn;
    /// <summary>
    /// Time between spawning new enemy in seconds
    /// </summary>
    public float spawnInterval;
}
