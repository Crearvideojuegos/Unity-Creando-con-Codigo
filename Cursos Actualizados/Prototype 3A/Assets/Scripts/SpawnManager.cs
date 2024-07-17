using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;

    private Vector3 _spawnPos = new Vector3(25, 0, 0);

    private float _startDelay = 2;
    private float _repeatRate = 2;
    private PlayerController _playerController;

    private void Start() 
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    private void SpawnObstacle()
    {
        if(_playerController.GameOver == false)
        {
            Instantiate(ObstaclePrefab, _spawnPos, ObstaclePrefab.transform.rotation);
        }
    }
}
