using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 30;
    private PlayerController _playerController;
    private float _leftBound = -15;

    private void Start() 
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void FixedUpdate() 
    {
        if(_playerController.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.fixedDeltaTime * _speed);
        }

        if(transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
