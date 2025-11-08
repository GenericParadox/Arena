using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// A HUD
/// </summary>	
public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject timeLeftTextGameObject;
    [SerializeField]
    GameObject scoreTextGameObject;
    [SerializeField]
    GameObject test1TextGameObject;
    [SerializeField]
    GameObject playerLostTextGameObject;
    [SerializeField]
    GameObject fpsTextGameObject;
    [SerializeField]
    GameObject playerGameObject;

    Timer scoreTimer;

    // time left text support
    const string TimeLeftPrefix = "Time Left: ";
    const string TimeLeftSuffix = " s";
    static int timeLeft = 0;
    static TextMeshProUGUI timeLeftText;

    // score text support
    const string ScorePrefix = "Score: ";
    static int score = 0;
    static TextMeshProUGUI scoreText;

    // player lost text support
    const string PlayerLostPrefix = "Failure... Dematerializing \n" + "Score:";
    static TextMeshProUGUI playerLostText;

    // fps text support
    const string FPSPrefix = "FPS: ";
    static float fps = 0;
    static TextMeshProUGUI fpsText;

    // Test text support
    const string TestPrefix = "Testing Invoker 1: ";
    static float test1 = 0;
    static TextMeshProUGUI test1Text;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the score
    /// </summary>
    public int Score
    {
        get { return score; }
    }

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {

        score = 0;
        scoreText = scoreTextGameObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = ScorePrefix + score.ToString();

        playerLostText = playerLostTextGameObject.GetComponent<TextMeshProUGUI>();

        fpsText = fpsTextGameObject.GetComponent<TextMeshProUGUI>();
        fpsText.text = ScorePrefix + fps.ToString();

        test1Text = test1TextGameObject.GetComponent<TextMeshProUGUI>();
        test1Text.text = TestPrefix + test1.ToString();

    }
    private void Update()
    {
        FPSTracker();
    }

    #endregion

    #region Private methods
    /// <summary>
    /// Ends the game
    /// </summary>
    /// <param name=""></param>
    void GameFinish()
    {
        //playerLostText.text = PlayerLostPrefix + score.ToString();
        MenuManager.GoToMenu(MenuName.EndGame, Score);
        //playerLostTextGameObject.SetActive(true);

    }

    /// <summary>
    /// Adds the given points to the score
    /// </summary>
    /// <param name="points">points to add</param>
    void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }

    /// <summary>
    /// Tracks the FPS
    /// </summary>
    void FPSTracker()
    {
        fpsText.text = FPSPrefix + FPSTarget.Fps;
    }

    /// <summary>
    /// Adds the given points to the score
    /// </summary>
    /// <param name="a">points to add</param>
    void Test1(int a, int b)
    {
        test1 = a*10 + b;
        test1Text.text = TestPrefix + test1.ToString();
    }

    #endregion

    #region Menu Navigation Support
    public void GoBack()
    {
        AudioManager.Instance.Play("ButtonClick");
        MenuManager.GoToMenu(MenuName.Main);
    }


    #endregion
}