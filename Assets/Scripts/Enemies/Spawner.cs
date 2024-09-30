using System;
using System.Collections;
using Enemies;
using UnityEngine;
using UnityEngine.AI;
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

    //Prototype: Object to clone
    private Enemy existingEnemy;
    
    private void OnEnable()
    {
        if (frequency > 0) period = 1 / frequency;

        // Initializing Pool with enemy data
        _enemyPool = new Pool<Enemy>(enemyPrefab, poolSize, transform);
        
        //Getting the Object
        existingEnemy = _enemyPool.Get();
        existingEnemy.gameObject.SetActive(false);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            for (int i = 0; i < spawnsPerPeriod; i++)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(period);
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy;
        
        //Implement Prototype to clone existing enemies
        if (_enemyPool.Count > 0) // Check avaliable pool enemies
        {
            enemy = _enemyPool.Get();
        }
        else // Clone an enemy
        {
            enemy = existingEnemy.Clone();
        }
        
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;

        // Calculete path and assign
        NavMeshPath path = new NavMeshPath();
        if (NavMesh.CalculatePath(transform.position, targets[Random.Range(0, targets.Length)].position, NavMesh.AllAreas, path))
        {
            enemy.SetPath(path);
        }

        enemy.Initialize(_enemyPool);
    }
}
