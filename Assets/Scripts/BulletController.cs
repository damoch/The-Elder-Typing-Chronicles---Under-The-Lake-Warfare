﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float BulletLife;
    

    void Start () {
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy") || collision.tag.Equals("DestructiveWall"))
        {
            DestroyGameObject();
            return;
        }

        if (collision.tag.Equals("Player"))
        {
            //todo if collision with player
            collision.GetComponent<PlayerController>().HitPoints -= 1;
            DestroyGameObject();
        }
    }
}
