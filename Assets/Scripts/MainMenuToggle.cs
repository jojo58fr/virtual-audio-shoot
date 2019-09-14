using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
/// <summary>
/// gestion des bouton du menu
/// </summary>
public class MainMenuToggle : MonoBehaviour {

	public VRTK_ControllerEvents controllerEvents;
	public GameObject menu;

	bool menuState = false;

	void OnEnable()
	{
		controllerEvents.ButtonTwoPressed += ControllerEvents_ButtonTwoPressed;
		controllerEvents.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;
	}

	void OnDisable()
	{
		controllerEvents.ButtonTwoPressed -= ControllerEvents_ButtonTwoPressed;
		controllerEvents.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;
	}

	void ControllerEvents_ButtonTwoReleased (object sender, ControllerInteractionEventArgs e)
	{
		menuState = !menuState;
		menu.SetActive (menuState);
	}

	void ControllerEvents_ButtonTwoPressed (object sender, ControllerInteractionEventArgs e)
	{

	}
}
