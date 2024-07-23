using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{

    public GameObject[] ObjectPrefabs;
    private float _spawnDelay = 2;
    private float _spawnInterval = 1.5f;

    private PlayerControllerX _playerControllerScript;

    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("SpawnObjects", _spawnDelay, _spawnInterval);
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, ObjectPrefabs.Length);

        // If game is still active, spawn new object
        if (!_playerControllerScript.GameOver)
        {
            Instantiate(ObjectPrefabs[index], spawnLocation, ObjectPrefabs[index].transform.rotation);
        }

    }
}
