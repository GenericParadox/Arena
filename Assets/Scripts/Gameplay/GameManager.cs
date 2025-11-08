using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using Unity.VisualScripting;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.Events;
using UnityEngine.LowLevel;

public class GameManager : MonoBehaviour
{
    #region Fields
    

    //Event support

    //Debugging
    #endregion

    #region Properties
   
    #endregion

    #region Methods
    /// <summary>
    /// Finds the Player and Initialises Grid 
    /// </summary>
    public void Initialize()
    {

       
    }
    void HandleMenuInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                MenuManager.GoToMenu(MenuName.Pause);
            }
            else
            {
                GameObject.Find("PauseMenu(Clone)").GetComponent<PauseMenu>().ResumeGame();
            }
        }
    }
    void Start()
    {
        Initialize();
    }
    void Update()
    {
        
    }
    #endregion
}
