using System;
using System.Collections;
using Enemies;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int spawnsPerPeriod = 10;
    [SerializeField] private float frequency = 30;
    [SerializeField] private float period = 0;
    [SerializeField] private int poolSize = 40;
    [SerializeField] private Transform[] targets;

    private Pool<Enemy> _enemyPool;

    private void OnEnable()
    {
        if (frequency > 0) period = 1 / frequency;

        // Initializing Pool with enemy data
        _enemyPool = new Pool<Enemy>(enemyPrefab, poolSize, transform);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            for (int i = 0; i < spawnsPerPeriod; i++)
            {
                SpawnEnemy(targets[Random.Range(0, targets.Length)]);
            }

            yield return new WaitForSeconds(period);
        }
    }

    private void SpawnEnemy(Transform structureTarget)
    {
        var enemy = _enemyPool.Get();
        enemy.transform.position = transform.GetChild(0).position;
        //enemy.transform.rotation = transform.rotation;
        
        //Set Enemy Target
        enemy.SetTarget(structureTarget);

        //Set Enemy pool
        enemy.Initialize(_enemyPool);
    }
}
