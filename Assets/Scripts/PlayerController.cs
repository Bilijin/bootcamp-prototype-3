using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded = true;
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource audioSource;
    public float gravityModifier;
    public float jumpForce = 10;
    public bool isGameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRB = gameObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound);
            isGrounded = false;
            dirtParticle.Stop();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            isGameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound);

            dirtParticle.Stop();
            explosionParticle.Play();
        }
    }
}
