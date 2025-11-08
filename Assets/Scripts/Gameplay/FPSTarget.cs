using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class FPSTarget
{
    public static int target = 60;
    public static float fps;
    public static float deltaTime;
    static bool initialized = false;


    /// <summary>
    /// Gets whether or not the FPSTarget has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    public static float Fps
    {
        get { return fps; }
    }

    public static void Initialize()
    {
        initialized = true;
    }

    public static void UpdateFrame()
    {
        if (Application.targetFrameRate != target)
        {
            Application.targetFrameRate = target;
        }
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fps = 1.0f / deltaTime;
        //fpsText.text = Mathf.Ceil(fps).ToString();
    }


}

