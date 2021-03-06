﻿using UnityEngine;

public abstract class Coin : MonoBehaviour {
    private void Start()
    {
        CoinGenerator.NumberOfCoins++;
    }

    private void DestroyGameObject()
    {
        CoinGenerator.NumberOfCoins--;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            DestroyGameObject();
            DoYourAction(collision.gameObject.GetComponent<PlayerController>());
        }
        if(collision.tag.Equals("DestructiveWall")) DestroyGameObject();
    }

    public abstract void DoYourAction(PlayerController playerController);
}
