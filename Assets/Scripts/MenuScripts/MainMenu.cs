using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main menu
/// </summary>	
public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        AudioManager.Instance.PlayMusic("ThemeIntro");
    }
    #region Public methods
    /// <summary>
    /// Goes to the difficulty menu
    /// </summary>
    public void GoToGameplay()
    {
        AudioManager.Instance.StopMusic("ThemeIntro");
        AudioManager.Instance.Play("ButtonClick");
        MenuManager.GoToMenu(MenuName.Quick);
    }

    /// <summary>
    /// Goes to the Main menu
    /// </summary>
    public void GoToMainMenu()
    {
        AudioManager.Instance.StopMusic("ThemeIntro");
        AudioManager.Instance.Play("ButtonClick");
        MenuManager.GoToMenu(MenuName.Quick);
    }

    /// <summary>
    /// Goes to the instructions menu
    /// </summary>
    public void GoToInstructionsMenu()
    {
        AudioManager.Instance.StopMusic("ThemeIntro");
        AudioManager.Instance.Play("ButtonClick");
        MenuManager.GoToMenu(MenuName.Instructions);
    }

    /// <summary>
    /// Goes to the options menu
    /// </summary>
    public void GoToSettingsMenu()
    {
        AudioManager.Instance.StopMusic("ThemeIntro");
        AudioManager.Instance.Play("ButtonClick");
        MenuManager.GoToMenu(MenuName.Settings);
    }

    /// <summary>
    /// Goes to the highscores menu
    /// </summary>
    public void GoToHighscoresMenu()
    {
        AudioManager.Instance.StopMusic("ThemeIntro");
        AudioManager.Instance.Play("ButtonClick");
        MenuManager.GoToMenu(MenuName.Highscores);
    }

    /// <summary>
    /// Shows the help menu
    /// </summary>
    public void ShowHelp()
    {
        AudioManager.Instance.StopMusic("ThemeIntro");
        AudioManager.Instance.Play("ButtonClick");
        MenuManager.GoToMenu(MenuName.Help);
    }

    /// <summary>
    /// Exits the game
    /// </summary>
    public void ExitGame()
    {
        AudioManager.Instance.StopMusic("ThemeIntro");
        AudioManager.Instance.Play("ButtonClick");
        Application.Quit();
    }

    #endregion

}
