using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method is called when the "Play Game" button is clicked
    public void Level1()
    {
        // Load the next scene in the build settings, which is the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Level2()
    {
        // Load the next scene in the build settings, which is the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // This method is called when the "Settings" button is clicked
    public void GotoSettingsMenu()
    {
        // Load the scene with the name "SettingsMenu"
        // Make sure you have added the "SettingsMenu" scene in the build settings
        SceneManager.LoadScene("Options");
    }

    public void GotoReadMe()
    {
        // Load the scene with the name "SettingsMenu"
        // Make sure you have added the "SettingsMenu" scene in the build settings
        SceneManager.LoadScene("ReadMe");
    }

    // This method is called when the "Main Menu" button is clicked
    public void GotoMainMenu()
    {
        // Load the scene with the name "MainMenu"
        // Make sure you have added the "MainMenu" scene in the build settings
        SceneManager.LoadScene("MainMenu");
    }

    // This method is called when the "Quit Game" button is clicked
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        // If you are running the game in the Unity editor, Application.Quit() won't close the editor.
        // You can use the following line of code for testing in the editor:
        //#if (UnityEditor == true)
       
         //UnityEditor.EditorApplication.isPlaying = false;
        // #endif
    }
}



