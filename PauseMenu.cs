using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI object

    public Timer timer;

    private bool isPaused = false; // Flag to track whether the game is paused

    void Start()
    {
        // Deactivate the pause menu UI when the game starts
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Check for pause input (e.g., pressing the Escape key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause state
            if (isPaused)
                ResumeGame(); // If the game is already paused, resume it
            else
                PauseGame(); // If the game is not paused, pause it
        }
    }

    // Function to pause the game
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Stop the time scale to pause the game
        pauseMenuUI.SetActive(true); // Show the pause menu UI
    }

    // Function to resume the game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Set the time scale back to normal to resume the game
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
    }

    // Function to restart the scene
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Ensure the time scale is set to normal after restarting the scene
        isPaused = false;
    }

    // Function to go to the main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu2"); // Replace "MainMenuScene" with the name of your main menu scene
        Time.timeScale = 1f; // Ensure the time scale is set to normal after going to the main menu
    }
}
