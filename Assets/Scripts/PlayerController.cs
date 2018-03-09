using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	public Rigidbody2D Bullet;
	Vector2 movement;
	public float smooth = 0.4f;

	public float goodKeyPower = 1f;
	public float badKeyPower = 1f;
	public float noKeyPower = 0.5f;
	public float SpeedOfBullet;

	
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		//rb.velocity = new Vector2(300,0) * Time.fixedDeltaTime; //Horizontal Movement
		movement = Vector2.zero;
		if(Input.GetKeyDown("up")){
			GoodKey();
		}else if(Input.GetKeyDown("down")){
			BadKey();
		}else{
			movement += Vector2.up * noKeyPower;
		}
		rb.velocity = Vector2.Lerp(rb.velocity, rb.velocity + movement, smooth);
		if(Input.GetKeyDown("space")){
			Shoot();
		}
	}

	public void GoodKey(){
		movement += Vector2.down * goodKeyPower;
		Camera.main.GetComponent<CameraController>().Shake(0.6f, 1);
	}
	public void BadKey(){
		movement += Vector2.up * badKeyPower;
		Camera.main.GetComponent<CameraController>().Shake(0.6f, 4);
	}
    private void Shoot()
    {
        Vector2 _renderDirection = new Vector2(transform.position.x - 2, transform.position.y);
        Rigidbody2D _bullet = Instantiate(Bullet, _renderDirection, Quaternion.identity) as Rigidbody2D;
        _bullet.AddForce(new Vector2(-SpeedOfBullet, 0));
    }
}
