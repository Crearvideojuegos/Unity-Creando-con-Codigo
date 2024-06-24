using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    private Vector2 _moveInput; //WASD Movement
    private InputMovement _inputMovement; //Input System
    private Rigidbody _rb;

    private void Awake() 
    {
        _inputMovement = new InputMovement();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _inputMovement.Enable();
    }

    private void Update() 
    {
        CaptureInput();
    }

    private void FixedUpdate()
    {
        // transform.Rotate(Vector3.right, 100f * Time.fixedDeltaTime * _moveInput.y);
        // transform.Translate(Vector3.forward * 0.5f);

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(RotationSpeed * Time.fixedDeltaTime * _moveInput.y, 0, 0));
        _rb.MoveRotation(_rb.rotation * deltaRotation);
        _rb.linearVelocity = transform.forward * Speed * Time.fixedDeltaTime;   
    }

    private void CaptureInput()
    {
        _moveInput = _inputMovement.Movement.Movement.ReadValue<Vector2>();
    }

}
