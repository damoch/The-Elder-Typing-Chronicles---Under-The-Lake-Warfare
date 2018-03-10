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
    public bool IsGameOver;
	// Use this for initialization
	void Start () {
        _rGameText = RGameText;
        RGame.gameObject.SetActive(false);
        IsGameOver = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void GameOver()
    {
        IsGameOver = true;
        RGame.gameObject.SetActive(true);
        var gObjects = FindObjectsOfType<BadGuyController>();
        for(var go = 0; go<gObjects.Length; go++)
        {
            Destroy(gObjects[go].gameObject);
        }

        var coins = FindObjectsOfType<Coin>();

        for (var go = 0; go < coins.Length; go++)
        {
            Destroy(coins[go].gameObject);
        }

        var bullets = FindObjectsOfType<BulletController>();

        for (var go = 0; go < bullets.Length; go++)
        {
            Destroy(bullets[go].gameObject);
        }
        RGame.T.text = RGameText;
    }

    internal void RestartGame()
    {
        IsGameOver = false;
        RGame.gameObject.SetActive(false);
        PController.StartNewGame();
        RGameText = _rGameText;
    }
}
