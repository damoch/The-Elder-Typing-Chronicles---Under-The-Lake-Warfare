using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float BulletLife;

    private Rigidbody2D _rigidbody;

    void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        
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
            //todo decrease life
            DestroyGameObject();
        }
    }
}
