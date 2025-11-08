using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public List<ScoreEntry> highScores = new List<ScoreEntry>();
    public TMP_InputField nameInputField;
    public GameObject scoreTableGameObject;
    static TextMeshProUGUI scoreTableText;
    private bool canSave = true;
    private string filePath;

    private void Awake()
    {
        canSave = true;
        filePath = Path.Combine(Application.persistentDataPath, "highscores.json");
        LoadScores();
        scoreTableText = scoreTableGameObject.GetComponent<TextMeshProUGUI>();
        UpdateScoresUIImproved();
    }

    public void UpdateScoresUI()
    {
        string score = "";
        foreach (ScoreEntry entry in highScores)
        {
            score += entry.PlayerName + " " + entry.Time + " " + entry.Points.ToString() + "\n";
        }
        scoreTableText.text = score;
    }

    public void UpdateScoresUIImproved()
    {
        var sortedScores = highScores.OrderByDescending(e => e.points).Take(5);
        StringBuilder sb = new StringBuilder();
        //sb.AppendLine("Name       Time       Points");
        foreach (ScoreEntry entry in sortedScores)
        {
            sb.AppendLine($"{entry.playerName,-10} {entry.time,-10} {entry.points.ToString()}");
        }

        scoreTableText.text = sb.ToString();
    }

    public void SaveSeuqence()
    {
        if (canSave)
        {
            string playerName = nameInputField.text.Length < 8 ? nameInputField.text : nameInputField.text.Substring(0, 7);
            
            Debug.Log("Player name is: " + playerName);
            ScoreEntry currentScoreEntry = new ScoreEntry(playerName);
            highScores.Add(currentScoreEntry);
            SaveScores();
            UpdateScoresUIImproved();
            canSave = false;
        }
    }

    public void SaveScores()
    {
        string json = JsonUtility.ToJson(new ScoreListWrapper(highScores), true);
        File.WriteAllText(filePath, json);
        Debug.Log($"Scores saved to {filePath}");
    }

    public void LoadScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            ScoreListWrapper wrapper = JsonUtility.FromJson<ScoreListWrapper>(json);
            highScores = wrapper.scores;
        }
        else
        {
            highScores = new List<ScoreEntry>();
        }
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

    [Serializable]
    private class ScoreListWrapper
    {
        public List<ScoreEntry> scores;

        public ScoreListWrapper(List<ScoreEntry> scores)
        {
            this.scores = scores;
        }
    }
}