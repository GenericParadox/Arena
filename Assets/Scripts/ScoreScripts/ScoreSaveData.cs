using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreSaveData
{
    public List<ScoreEntry> highScores = new List<ScoreEntry>();
    public int overallPoints = 0;
    public List<SkinPreset> skinPresets = new List<SkinPreset>();
}