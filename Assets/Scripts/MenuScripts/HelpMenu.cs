using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The help menu
/// </summary>
public class HelpMenu : MonoBehaviour
{
	#region Public methods

	/// <summary>
	/// Goes back to the main menu
	/// </summary>
	public void GoBack()
	{
        AudioManager.Instance.Play("ButtonClick");
        MenuManager.GoToMenu(MenuName.Main);
	}

	#endregion
}