using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private InAcPlayerController _inAcPlayerController; //Input System

    public bool GameOver;

    public float FloatForce;
    private float _gravityModifier = 1.5f;
    private Rigidbody _playerRb;

    public ParticleSystem ExplosionParticle;
    public ParticleSystem FireworksParticle;

    private AudioSource _playerAudio;
    public AudioClip MoneySound;
    public AudioClip ExplodeSound;


    // Start is called before the first frame update
    void Awake()
    {
        GameOver = false;
        _inAcPlayerController = new InAcPlayerController();
        Physics.gravity *= _gravityModifier;
        _playerAudio = GetComponent<AudioSource>();
        _playerRb = GetComponent<Rigidbody>();

    }

    private void Start() 
    {
        _inAcPlayerController.Enable();
        _inAcPlayerController.Player.Jump.performed += ctx => Jump();
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set GameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            ExplosionParticle.Play();
            _playerAudio.PlayOneShot(ExplodeSound, 1.0f);
            GameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            FireworksParticle.Play();
            _playerAudio.PlayOneShot(MoneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

    private void Jump()
    {

        // While space is pressed and player is low enough, float up
        if (!GameOver && IsLowEnough())
        {
            _playerRb.AddForce(Vector3.up * FloatForce, ForceMode.Impulse);
        }
    }

    private bool IsLowEnough()
    {
        if(transform.position.y < 15f)
        {
            return true;
        }

        return false;
    }

}
