using System.Collections.Generic;
using UnityEngine;

public class BadGuyController : MonoBehaviour {

    public Rigidbody2D Bullet;
    public float SpeedOfBullet;
    public float ShootInterval;
    public List<AudioClip> LaserClips;
    public List<AudioClip> ExplosionClips;


    private float _badGuyLife;
    private Rigidbody2D _rigidbody;
    private float _shootTime;

    void Start () {
        Generator.NumberOfObjects++;
        _rigidbody = GetComponent<Rigidbody2D>();
        _badGuyLife = 1;
        _shootTime = 0;
        ShootInterval += UnityEngine.Random.Range(0, 2);
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
        Generator.NumberOfObjects--;
        GetComponent<AudioSource>().PlayOneShot(ExplosionClips[Random.Range(0, ExplosionClips.Count - 1)]);
        Destroy(gameObject);
    }

    public void GetShoot()
    {
        DestroyGameObject();
    }

    private void Shoot()
    {
        GetComponent<AudioSource>().PlayOneShot(LaserClips[Random.Range(0, LaserClips.Count - 1)]);
        var _renderDirection = new Vector2(transform.position.x - 2, transform.position.y);
        var _bullet = Instantiate(Bullet, _renderDirection, Quaternion.identity) as Rigidbody2D;
        _bullet.AddForce(new Vector2(-SpeedOfBullet, 0));
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DestructiveWall"))
        {
            DestroyGameObject();
            return;
        }

        if (collision.tag.Equals("Player"))
        {
            collision.GetComponent<PlayerController>().HitPoints -= 1;
            DestroyGameObject();
        }
    }
}
