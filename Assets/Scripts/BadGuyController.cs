using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyController : MonoBehaviour {

    public Rigidbody2D Bullet;
    public float SpeedOfBullet;
    public float ShootInterval;

    private float _badGuyLife;
    private Rigidbody2D _rigidbody;
    private float _shootTime;

    void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _badGuyLife = 1;
        _shootTime = 0;
        ShootInterval += UnityEngine.Random.Range(0, 1);
    }
	
	void Update () {

        if (_badGuyLife < 0)
        {
            DestroyGameObject();
        }

        _shootTime += Time.deltaTime;
        if (_shootTime > ShootInterval)
        {
            Shoot();
            _shootTime = 0;
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
        Vector2 _renderDirection = new Vector2(transform.position.x - 2, transform.position.y);
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
