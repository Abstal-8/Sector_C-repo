using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody playerRB;
    private GameObject enemy;
    private GameManager gameManager;
    public Enemy enemyAttack;
    public AudioClip playerDamageSound;
    private AudioSource playerSounds;
    private float verticalRotateSpeed = 3.0f;
    public int playerHealth = 10;
   

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerSounds = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemy = GameObject.Find("Enemy");
    }    

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (playerHealth <= 0)
        {
            gameManager.GameOver();
        }
        
        if (!gameManager.isGameOver && gameManager.isPlayButtonClicked)
        {
            playerRB.AddForce(Vector3.forward.normalized * horizontalInput * speed);
        playerRB.AddForce(Vector3.left.normalized * verticalInput * speed);

            float v = verticalRotateSpeed * Input.GetAxis("Mouse X");
                    transform.Rotate(0, v, 0);    
        }

        
    }

    private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Enemy"))
      {
        playerHealth = playerHealth - enemyAttack.enemyDamage;
        playerSounds.PlayOneShot(playerDamageSound);
        gameManager.HealthLoss(playerHealth);
      }
   }

   
}
