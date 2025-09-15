using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject player;
    private float enemyHealth = 10.0f;
    private int enemyScore = 5;
    private AudioSource enemyAudio;
    private PlayerController playerControllerScript;
    private GameManager gameManager;
    public AudioClip ImpactNoise;
    public AudioClip DeathNoise;
    public BulletMovement bulletProperty;
    public float enemySpeed = 1.0f;
    public int enemyDamage = 2;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
      if (!gameManager.isGameOver && gameManager.isPlayButtonClicked)
      {
        enemyRB.AddForce((player.transform.position - transform.position * enemySpeed).normalized);
      }
      
      if (enemyHealth <= 0)
      {
        AudioSource.PlayClipAtPoint(DeathNoise, transform.position);
        Destroy(this.gameObject);
        gameManager.UpdateScore(enemyScore);
      }
      
    }


   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Projectile"))
      {
        enemyAudio.PlayOneShot(ImpactNoise, 0.5f);
        enemyHealth = enemyHealth - bulletProperty.bulletDamage;
      }
   }


}
