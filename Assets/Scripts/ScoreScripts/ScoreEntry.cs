using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreEntry
{
    #region Fields
    public string playerName;
    public string time; // Format: "MM:SS:ms" (e.g., 59:59:599)
    public int points;
    #endregion

    #region Properties
    public string PlayerName { get { return playerName; } set { playerName = value; } }
    public string Time { get { return time; } }
    public int Points { get { return points; } }
    #endregion

    #region ConstructorScoreEntry
    public ScoreEntry(string playerName = "AAAAA")
    {
        this.playerName = playerName;
        //this.time = FormatTime(GameObject.FindGameObjectWithTag("PC").GetComponent<Player>().MainTimer.ElapsedSeconds);
        this.time = "00.00.00"; //just for testing the saving function
        this.points = GameObject.Find("HUD").GetComponent<HUD>().Score;
        //this.points = 56; just for testing the saving function
    }
    #endregion

    #region ScoreSaveData
    [System.Serializable]
    public class ScoreSaveData
    {
        public List<ScoreEntry> highScores = new List<ScoreEntry>();
        public int overallPoints = 0;
        public List<SkinPreset> skinPresets = new List<SkinPreset>();
    }
    #endregion

    #region Methods
    private string FormatTime(TimeSpan timeSpan)
    {
        return string.Format("{0:D2}:{1:D2}:{2:D3}",
            timeSpan.Minutes,
            timeSpan.Seconds,
            timeSpan.Milliseconds);
    }
    #endregion
}