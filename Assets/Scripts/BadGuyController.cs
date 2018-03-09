using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyController : MonoBehaviour {

    public Rigidbody2D Bullet;
    public float BadGuyLife;
    public float SpeedOfBullet;

    private Rigidbody2D _rigidbody;
    Vector2 _renderDirection;

    void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        //if (BadGuyLife < 0)
        //{
        //    DestroyGameObject();
        //    return;
        //}

        //BadGuyLife -= Time.deltaTime;

        float _tmp = UnityEngine.Random.Range(0, 100);
        if (_tmp > 98)
        {
            Shoot();
        }
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void GetShoot()
    {
        DestroyGameObject();
    }

    private void Shoot()
    {
        _renderDirection = new Vector2(transform.position.x - 2, transform.position.y);
        Rigidbody2D _bullet = Instantiate(Bullet, _renderDirection, Quaternion.identity) as Rigidbody2D;
        _bullet.AddForce(new Vector2(-SpeedOfBullet, 0));
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DestructiveWall"))
        {
            DestroyGameObject();
            return;
        }
    }
}
