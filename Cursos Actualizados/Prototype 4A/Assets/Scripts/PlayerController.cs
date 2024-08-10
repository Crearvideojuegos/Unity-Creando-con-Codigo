using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InAcPlayerController _inAcPlayerController; //Input System
    private Vector2 _moveInput; //WASD Movement
    private Rigidbody playerRb;
    public float speed = 5f;
    private GameObject focalPoint;
    public bool hasPowerUp;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    private void Awake() 
    {
        _inAcPlayerController = new InAcPlayerController();
    }

    private void Start()
    {
        _inAcPlayerController.Enable();
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void Update()
    {
        CaptureInput();
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void FixedUpdate() 
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * _moveInput.y);
    }

    private void CaptureInput()
    {
        _moveInput = _inAcPlayerController.Player.MovePlayer.ReadValue<Vector2>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with" + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerUp = false;
    }


}
