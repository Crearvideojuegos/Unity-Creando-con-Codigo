using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject DogPrefab;
    private PlayerActions _playerActions; //Input System
    private bool _canShoot;
    private float _timeShoot;

    // Update is called once per frame
    private void Awake() 
    {
        _playerActions = new PlayerActions();
    }

    private void Start()
    {
        _playerActions.Enable();
        _playerActions.PlayerController.Shoot.performed += ctx => Shoot();
        _canShoot = true;
    }

    private void FixedUpdate() 
    {
        PlayerCanShoot();
    }

    private void Shoot()
    {
        if(_canShoot)
        {
            Instantiate(DogPrefab, transform.position, DogPrefab.transform.rotation);
            _canShoot = false;
            _timeShoot = 0f;
        }
    }

    private void PlayerCanShoot()
    {
        if(!_canShoot)
        {
            if(_timeShoot > 3f)
            {
                _canShoot = true;
            }
        }
        
        _timeShoot += Time.deltaTime;
    }

}