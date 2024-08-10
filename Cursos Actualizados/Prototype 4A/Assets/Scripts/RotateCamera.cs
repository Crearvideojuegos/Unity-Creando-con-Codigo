using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private InAcPlayerController _inAcPlayerController; //Input System
    private Vector2 _moveInput; //WASD Movement
    public float rotationSpeed;

    private void Awake() 
    {
        _inAcPlayerController = new InAcPlayerController();
    }

    private void Start()
    {
        _inAcPlayerController.Enable();
    }

    private void Update()
    {
        CaptureInput();
    }

    private void FixedUpdate() 
    {
        transform.Rotate(Vector3.up, _moveInput.x * rotationSpeed * Time.deltaTime);
    }

    private void CaptureInput()
    {
        _moveInput = _inAcPlayerController.Player.RotateCamera.ReadValue<Vector2>();
    }


}
