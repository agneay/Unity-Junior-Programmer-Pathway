using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce = 11;
    private Animator playerAnim;
    private Rigidbody playerRb;
    public float gravityModifier = 1.0f;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        //jump();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // Jump
            jump();

        }
    }

    void jump()
    {
        playerAudio.PlayOneShot(jumpSound, 1.0f);
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger("Jump_trig");
        dirtSplatter.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtSplatter.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            explosionParticle.Play();
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
