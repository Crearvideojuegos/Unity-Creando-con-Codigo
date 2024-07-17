using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InAcPlayerController _inAcPlayerController; //Input System
    private Rigidbody _playerRB;
    public float JumpForce;
    public float GravityModifier;
    public bool IsOnGround = true;
    public bool GameOver;
    private Animator _playerAnim;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip JumpSound;
    public AudioClip CrashSound;
    private AudioSource _playerAudio;


    private void Awake() 
    {
        _inAcPlayerController = new InAcPlayerController();
        _playerRB = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        _inAcPlayerController.Enable();
        _inAcPlayerController.Player.Jump.performed += ctx => Jump();
    }

    private void Jump()
    {
        if(IsOnGround && !GameOver)
        {
            _playerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
            DirtParticle.Stop();
            _playerAudio.PlayOneShot(JumpSound, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            DirtParticle.Play();
        } 
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            ExplosionParticle.Play();
            GameOver = true;
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            DirtParticle.Stop();
            _playerAudio.PlayOneShot(CrashSound, 1f);
            Debug.Log("Game Over!");
        }   
    }

}
