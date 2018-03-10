﻿using System;
using System.Collections;
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
    private float _frameGravDiff;
    private float _frameAntigravDiff;
    
    public bool HasShield = false;
    public bool HasBullet = false;
    public bool IsShieldOn;
    public GameObject ForceField;
    private void Start () {
        ForceField.SetActive(HasShield);
        InvokeRepeating("NoKey", 1f, 1f);
	}
	
	private void FixedUpdate () {
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

    private void NoKey()
    {
        if(GravitationForce > 0)
            GravitationForce -= _frameGravDiff;

        AntiGravitationForce += _frameAntigravDiff/2;
    }
    public void Shoot()
    {
        var _spawnDirection = new Vector2(transform.position.x + 4, transform.position.y);
        var _bullet = Instantiate(Bullet, _spawnDirection, Quaternion.identity) as Rigidbody2D;
        _bullet.AddForce(new Vector2(SpeedOfBullet, 0));
        HasBullet = false;
    }

	public int HitPoints{
		set{
            if (IsShieldOn) return;
			hitPoints = value;
			if(hitPoints <= 0){
				Debug.Log("GAME OVER!");
			}
		}
		get{
			return hitPoints;
		}
	}

    public float ShieldTimeoutLength { get; private set; }

    internal void Shield()
    {
        IsShieldOn = true;
        HasShield = false;
        ForceField.SetActive(true);
    }

    private IEnumerator ShieldTimeout()
    {
        yield return new WaitForSeconds(ShieldTimeoutLength);
        IsShieldOn = false;
        ForceField.SetActive(false);
    }
}
