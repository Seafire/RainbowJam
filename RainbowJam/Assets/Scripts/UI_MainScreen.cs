﻿using UnityEngine;
using System.Collections;

public class UI_MainScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel (1);
	}

	public void QuitGame()
	{
		Application.Quit();

	}
}
