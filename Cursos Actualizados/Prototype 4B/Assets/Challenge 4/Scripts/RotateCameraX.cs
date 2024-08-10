using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    private InAcPlayerController _inAcPlayerController; //Input System
    private Vector2 _moveInput; //WASD Movement
    private float speed = 200;
    public GameObject player;

    private void Awake() 
    {
        _inAcPlayerController = new InAcPlayerController();
    }

    private void Start()
    {
        _inAcPlayerController.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        CaptureInput();
        transform.position = player.transform.position; // Move focal point with player
    }

    private void FixedUpdate() 
    {
        transform.Rotate(Vector3.up, _moveInput.x * speed * Time.deltaTime);
    }

    private void CaptureInput()
    {
        _moveInput = _inAcPlayerController.Player.RotateCamera.ReadValue<Vector2>();
    }


}
