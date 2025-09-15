using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public GameObject tutorialScreen;
    public Button restartButton;
    public Button playButton;
    public bool isGameOver;
    public bool isPlayButtonClicked;


    private int score = 0;
    private int highScore;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
         playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int addScore)
   {
        score += addScore;
        scoreText.text = "Score: " + score;
   }

   public void HealthLoss(int playerHealth)
   {
     
        healthText.text = "Health: " + playerHealth;
        if (playerHealth < 0)
        {
            playerHealth = 0;
            healthText.text = "Health: " + playerHealth;
        }
   }

   public void GameOver()
   {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
   }

   public void RestartGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void StartGame()
   {
     isPlayButtonClicked = true;
     titleScreen.SetActive(false);
     tutorialScreen.SetActive(false);
     scoreText.text = "Score: " + score;
     healthText.text = "Health: " + playerControllerScript.playerHealth;
   }
}
