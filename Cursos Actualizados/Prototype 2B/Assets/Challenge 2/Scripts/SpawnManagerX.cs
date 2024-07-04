using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] BallPrefabs;

    private float _spawnLimitXLeft = -22;
    private float _spawnLimitXRight = 7;
    private float _spawnPosY = 30;

    private float _startDelay = 1.0f;
    private float _spawnIntervalOne = 4.0f;
    private float _spawnIntervalTwo = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", _startDelay, Random.Range(_spawnIntervalOne, _spawnIntervalTwo));
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(_spawnLimitXLeft, _spawnLimitXRight), _spawnPosY, 0);
        int ballIndex = Random.Range(0, BallPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(BallPrefabs[ballIndex], spawnPos, BallPrefabs[ballIndex].transform.rotation);
    }

}