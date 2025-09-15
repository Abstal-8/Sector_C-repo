using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    public GameObject bulletProjectile;
    public AudioClip bulletNoise;
    private AudioSource playerNoise;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        playerNoise = GetComponent<AudioSource>(); 
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.isGameOver && gameManager.isPlayButtonClicked)
            {
               playerNoise.PlayOneShot(bulletNoise); 
               Instantiate(bulletProjectile, transform.position, transform.rotation);
            }
    }
}
