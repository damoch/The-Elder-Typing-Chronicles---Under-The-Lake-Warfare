using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyController : MonoBehaviour {

    public float BadGuyLife;

    private Rigidbody2D _rigidbody;

	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (BadGuyLife < 0)
        {
            DestroyGameObject();
        }

        BadGuyLife -= Time.deltaTime;
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void GetShoot()
    {
        DestroyGameObject();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print("Touched BadGuy D:");
    }
}
