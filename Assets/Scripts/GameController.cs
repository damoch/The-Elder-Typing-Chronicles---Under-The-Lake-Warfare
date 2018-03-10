using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public RestertGameTextController RGame;
    public string RGameText;
    public PlayerController PController;
    private string _rGameText;
	// Use this for initialization
	void Start () {
        _rGameText = RGameText;
        RGame.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void GameOver()
    {
        RGame.gameObject.SetActive(true);
        RGame.T.text = RGameText;
    }

    internal void RestartGame()
    {
        RGame.gameObject.SetActive(false);
        PController.StartNewGame();
        RGameText = _rGameText;
    }
}
