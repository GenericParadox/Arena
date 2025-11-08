using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// The game over message
/// </summary>
public class GameOverMessage : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI messageText;
    [SerializeField]
    TextMeshProUGUI scoreTableText;
    [SerializeField]
    string currentScores;
    ScoreManager scoreManager;
    GameObject hud;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // pause the game when added to the scene
        if (hud == null)
        {
            hud = GameObject.Find("HUD");
        }
        if(scoreManager == null)
        {
            scoreManager = hud.GetComponent<ScoreManager>();
        }
        SetScore(hud.GetComponent<HUD>().Score);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Load Current Scores
    /// </summary>
    /// <param name="score">score</param>

    /// <summary>
    /// Sets score
    /// </summary>
    /// <param name="score">score</param>
    public void SetScore(int score)
    {
        messageText.text = "Failure! Dematerializing...\n\nYour score: " +
            score.ToString();
    }

    /// <summary>
    /// Moves to main menu when quit button clicked
    /// </summary>
    public void HandleQuitButtonClicked()
    {
        // unpause game, destroy menu, and go to main menuS
        Time.timeScale = 1;
        AudioManager.Instance.Play("ButtonClick");
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
