using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10f;
    public float gravityModifier;
    public int jumpCount = 0;
    public bool gameOver = false;
    public int jumpCountMax = 2;
    public bool booster = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        dirtParticle.Play();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount++ < jumpCountMax && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            booster = true;
            playerAnim.SetFloat("Booster_f", 1.5f);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            booster = false;
            playerAnim.SetFloat("Booster_f", 1.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log($"OnCollisionEnter : {other.gameObject}");

        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            dirtParticle.Play();
        } 
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
        }
    }
}
