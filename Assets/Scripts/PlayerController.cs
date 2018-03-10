using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D Bullet;
	public float SpeedOfBullet;
    public float GravitationForce;//down
    public float AntiGravitationForce;//up
    public float BaseAntiGravitation;
    public float AntiGravitationInc;
    public float GravitationInc;
    public float AntiGravitationNoInputIncrement;
    public float ForceDiff;
    public float GravTreshold;
    public float AntigravTreshold;
    
	private int hitPoints = 1;
    private Rigidbody2D rb;
    private float _frameGravDiff;
    private float _frameAntigravDiff;
    
    private bool _hasShield = false;
    private bool _hasBullet = false;

    void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        var y = Math.Abs(transform.position.y);
        _frameGravDiff = (y / AntigravTreshold) * GravitationInc;
        _frameAntigravDiff = (y / AntigravTreshold) * AntiGravitationInc;
        ForceDiff = AntiGravitationForce - GravitationForce;
        transform.Translate(0f, ForceDiff, 0f);

    }

	public void GoodKey(){
        GravitationForce += _frameGravDiff;
		Camera.main.GetComponent<CameraController>().Shake(0.6f, 1);
	}
	public void BadKey(){
        AntiGravitationForce += _frameAntigravDiff;
        Camera.main.GetComponent<CameraController>().Shake(0.6f, -1);
	} 
    public void Shoot()
    {
        var _spawnDirection = new Vector2(transform.position.x + 4, transform.position.y);
        var _bullet = Instantiate(Bullet, _spawnDirection, Quaternion.identity) as Rigidbody2D;
        _bullet.AddForce(new Vector2(SpeedOfBullet, 0));
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

    public void GetShield()
    {
        _hasShield = true;
    }

    public void GetBullet()
    {
        _hasBullet = true;
    }
}
