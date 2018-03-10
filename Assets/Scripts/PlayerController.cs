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
    public float GravitationForce;//down
    public float AntiGravitationForce;//up
    public float BaseAntiGravitation;
    public float AntiGravitationInc;
    public float GravitationInc;
    public float AntiGravitationNoInputIncrement;
    public float ForceDiff;
	
	int hitPoints = 1;

	
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
			//movement += Vector2.up * noKeyPower;
		}
		//rb.velocity = Vector2.Lerp(rb.velocity, rb.velocity + movement, smooth);
		if(Input.GetKeyDown("space")){
			Shoot();
		}
        ForceDiff = AntiGravitationForce - GravitationForce;
        transform.Translate(0f, ForceDiff, 0f);
        if(AntiGravitationForce < BaseAntiGravitation)
            AntiGravitationForce += AntiGravitationNoInputIncrement;

    }

	public void GoodKey(){
        GravitationForce += GravitationInc;
		Camera.main.GetComponent<CameraController>().Shake(0.6f, 1);
	}
	public void BadKey(){
        AntiGravitationForce += AntiGravitationInc;
        Camera.main.GetComponent<CameraController>().Shake(0.6f, -1);
	} 
    private void Shoot()
    {
        Vector2 _renderDirection = new Vector2(transform.position.x - 2, transform.position.y);
        Rigidbody2D _bullet = Instantiate(Bullet, _renderDirection, Quaternion.identity) as Rigidbody2D;
        _bullet.AddForce(new Vector2(-SpeedOfBullet, 0));
    }

	public int HitPoints{
		set{
			hitPoints = value;
			if(hitPoints <= 0){
				Debug.Log("GAME OVER!");
			}
		}
		get{
			return hitPoints;
		}
	}
}
