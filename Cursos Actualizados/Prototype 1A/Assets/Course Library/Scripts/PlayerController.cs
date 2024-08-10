using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private int _horizontalMovement;
	// private int _verticalMovement;
    public float Speed;
    public float TurnSpeed;

    private InputMovement _inputMovement; //Input System
    private Vector2 _moveInput; //WASD Movement

    private void Awake() 
    {
        _inputMovement = new InputMovement();
    }

    private void Start()
    {
        _inputMovement.Enable();
    }

    private void Update() 
    {
        // CaptureKeys();
        CaptureInput();
    }

    private void FixedUpdate() 
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * Speed * _moveInput.y);
        transform.Rotate(Vector3.up, Time.fixedDeltaTime * TurnSpeed * _moveInput.x);
    }


    private void CaptureInput()
    {
        _moveInput = _inputMovement.Movement.Movement.ReadValue<Vector2>();
    }


	// private void CaptureKeys()
    // {
    //     if(Input.GetKey(KeyCode.W))
    //     {
    //         _verticalMovement = 1;
    //     } 
    //     else if(Input.GetKey(KeyCode.S))
    //     {
    //         _verticalMovement = -1;
    //     }
    //     else 
    //     {
    //         _verticalMovement = 0;
    //     }

    //     if(Input.GetKey(KeyCode.A))
    //     {
    //         _horizontalMovement = -1;
    //     } 
    //     else if(Input.GetKey(KeyCode.D))
    //     {
    //         _horizontalMovement = 1;
    //     }
    //     else 
    //     {
    //         _horizontalMovement = 0;
    //     }
    // }

}
