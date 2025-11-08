using UnityEngine;

[System.Serializable]
public class SkinPreset
{
    public string skinName;
    public string colorHex; // Example: "#FF00FF"

    public SkinPreset(string skinName, Color color)
    {
        this.skinName = skinName;
        this.colorHex = ColorUtility.ToHtmlStringRGB(color);
    }

    public Color GetColor()
    {
        Color color;
        if (ColorUtility.TryParseHtmlString("#" + colorHex, out color))
            return color;
        return Color.white;
    }
}