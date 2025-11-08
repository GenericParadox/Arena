using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The menu manager
/// </summary>
public static class MenuManager
{
    /// <summary>
    /// Goes to the menu with the given name
    /// </summary>
    /// <param name="menu">menu to go to</param>
    public static void GoToMenu(MenuName menu, int finalScore = 0)
    {
        switch (menu)
        {
            case MenuName.Quick:

                // go to Difficulty Menu scene
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuName.Difficulty:

                // go to Difficulty Menu scene
                SceneManager.LoadScene("DifficultyMenu");
                break;
            case MenuName.Help:

                // go to Help Menu scene
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Main:

                // go to Main Menu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                
                // instantiate prefab
                Object.Instantiate(Resources.Load("Prefabs/PauseMenu"));
                break;
            case MenuName.Highscores:
                // instantiate prefab
                Object.Instantiate(Resources.Load("Prefabs/Highscores"));
                break;
            case MenuName.Settings:
                // instantiate prefab
                Object.Instantiate(Resources.Load("Prefabs/Settings"));
                break;
            case MenuName.Instructions:
                // instantiate prefab
                Object.Instantiate(Resources.Load("Prefabs/Instructions"));
                break;
            case MenuName.EndGame:
                // instantiate end screen
                Object.Instantiate(Resources.Load("Prefabs/GameOverMessage"));
                //GameObject.Find("GameObecrMessage").GetComponent<GameOverMessage>().SetScore(finalScore); 
                break;
        }
    }
}
