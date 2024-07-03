using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float _timeShoot;
    private bool _canShoot = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && _canShoot)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _canShoot = false;
            _timeShoot = 0f;
        }

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
