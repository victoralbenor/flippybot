using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Setup")]
    public float maxY = 0.7f;
    public float minY = -0.7f;
    public GameObject[] obstaclePool;
    
    [Header("Difficulty Settings")]
    public float timeBetweenObstacles = 1f;
    public float timeBetweenEachDifficultyIncrease = 1f;
    public float difficultyMultiplier = 0.1f;
    public float difficultyIncreaseStep = 0.1f;

    private int _nextObstacle = 0;
    private float _maxDistanceOnHardestMode;
    private float _maxDistanceBasedOnLevel;
    private float _newDistance;
    private float _oldY;
    private float _newY;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0f, timeBetweenObstacles);
        InvokeRepeating(nameof(IncreaseDifficulty), timeBetweenEachDifficultyIncrease, timeBetweenEachDifficultyIncrease);
    }

    private void SpawnObstacle()
    {
        _maxDistanceOnHardestMode = Mathf.Abs(minY) + Mathf.Abs(maxY);
        _maxDistanceBasedOnLevel = _maxDistanceOnHardestMode * difficultyMultiplier;
        _newDistance = Random.Range(0f, _maxDistanceBasedOnLevel);
        _oldY = obstaclePool[_nextObstacle].transform.position.y;
        _newY = Random.Range(_oldY - _newDistance / 2f, _oldY + _newDistance / 2f);
        _newY = Mathf.Clamp(_newY, minY, maxY);
        obstaclePool[_nextObstacle].transform.position = new Vector3(transform.position.x, _newY, 0f);;

        _nextObstacle++;
        if (_nextObstacle >= obstaclePool.Length) _nextObstacle = 0;
    }

    private void IncreaseDifficulty()
    {
        difficultyMultiplier += difficultyIncreaseStep;
        if (difficultyMultiplier > 1.0f) difficultyMultiplier = 1.0f;
    }
}
