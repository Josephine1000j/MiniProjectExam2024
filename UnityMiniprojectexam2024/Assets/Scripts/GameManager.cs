using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public Text uiDistance;        // Reference to the distance UI text
    public Text uiCoins;           // Reference to the coins UI text
    public int coinsCollected = 0; // Counter for coins collected

    public GameObject gameOverPanel; // Reference to the Game Over Panel
    public Text finalDistanceText;   // Text element for the final distance
    public Text finalCoinsText;      // Text element for the final coins
    private bool isGameOver = false; // Prevent multiple Game Over triggers

    void Start()
    {
        player = GameObject.Find("Player"); // Ensure the player object is named "Player" in Unity
        UpdateCoinUI();                     // Initialize coin count display
        gameOverPanel.SetActive(false);     // Make sure the Game Over Panel is hidden at the start
    }

    void Update()
    {
        if (isGameOver) return; // Don't update distance if the game is over

        // Update distance UI
        int distance = Mathf.RoundToInt(player.transform.position.z);
        uiDistance.text = "Distance: " + distance.ToString() + "m";
    }

    // Call this method to update the coin count and UI
    public void AddCoin()
    {
        coinsCollected++;
        UpdateCoinUI();
    }

    // Updates the coin count on the UI
    private void UpdateCoinUI()
    {
        uiCoins.text = "Coins: " + coinsCollected.ToString();
    }

    public void GameOver()
    {
        if (isGameOver) return; // Prevent multiple triggers
        isGameOver = true;

        // Show the Game Over Panel
        gameOverPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0;

        // Get current scores
        int distance = Mathf.RoundToInt(player.transform.position.z);

        // Get high scores from PlayerPrefs
        int highScoreDistance = PlayerPrefs.GetInt("HighScoreDistance", 0);
        int highScoreCoins = PlayerPrefs.GetInt("HighScoreCoins", 0);

        // Update high scores if necessary
        if (distance > highScoreDistance)
        {
            PlayerPrefs.SetInt("HighScoreDistance", distance);
            highScoreDistance = distance;
        }

        if (coinsCollected > highScoreCoins)
        {
            PlayerPrefs.SetInt("HighScoreCoins", coinsCollected);
            highScoreCoins = coinsCollected;
        }

        // Update UI text for high scores and current scores
        UpdateGameOverUI(distance, highScoreDistance, coinsCollected, highScoreCoins);
    }

    private void UpdateGameOverUI(int currentDistance, int highScoreDistance, int currentCoins, int highScoreCoins)
    {
        // Log current high scores to debug
        Debug.Log("Current Distance: " + currentDistance);
        Debug.Log("High Score Distance: " + highScoreDistance);
        Debug.Log("Current Coins: " + currentCoins);
        Debug.Log("High Score Coins: " + highScoreCoins);

        // Update final distance and high score
        if (finalDistanceText != null)
        {
            finalDistanceText.text = $"Distance: {currentDistance}m\nHigh Score: {highScoreDistance}m";
        }
        else
        {
            Debug.LogWarning("finalDistanceText is not assigned in the Inspector!");
        }

        // Update final coins and high score
        if (finalCoinsText != null)
        {
            finalCoinsText.text = $"Coins: {currentCoins}\nHigh Score: {highScoreCoins}";
        }
        else
        {
            Debug.LogWarning("finalCoinsText is not assigned in the Inspector!");
        }
    }


    public void RestartGame()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene to restart
    }

    public void QuitGame()
    {
        // Optional: Add functionality to quit the game
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
