using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float _minSpeed = 12.0f;
    private float _maxSpeed = 16.0f;
    private float _maxTorque = 10.0f;
    private float _xRange = 4.0f;
    private float _ySpawnPos = -6.0f;

    private GameManager _gameManager;
    public int PointValue;
    public ParticleSystem ExplosionParticle;

    private void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (_gameManager.IsGameActive)
        {
            Destroy(gameObject);
            Instantiate(ExplosionParticle, transform.position, ExplosionParticle.transform.rotation);
            _gameManager.UpdateScore(PointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")) { _gameManager.GameOver(); } 
    }

    

}
