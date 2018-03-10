using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    private float _startY;
    public GameObject ForceField;
    public GameController GameController;

    public Text HasShieldText;
    public Text HasBulletText;

    private void Start () {
        ForceField.SetActive(HasShield);
        InvokeRepeating("NoKey", 1f, 1f);
        _startY = transform.position.y;
	}
	
	private void FixedUpdate () {
        if (!gameObject.activeInHierarchy) return;
        var y = Math.Abs(transform.position.y);
        _frameGravDiff = (y / AntigravTreshold) * GravitationInc;
        _frameAntigravDiff = (y / AntigravTreshold) * AntiGravitationInc;
        ForceDiff = AntiGravitationForce - GravitationForce;
        transform.Translate(0f, ForceDiff, 0f);
        y = transform.position.y;
        if (y > AntigravTreshold || y < GravTreshold) GameOver();

    }

	public void GoodKey()
    {
        GravitationForce += _frameGravDiff;
	}
	public void BadKey(){
        AntiGravitationForce += _frameAntigravDiff;
	} 

    private void NoKey()
    {
        if (!gameObject.activeInHierarchy) return;
        if (GravitationForce > 0)
            GravitationForce -= _frameGravDiff;

        AntiGravitationForce += _frameAntigravDiff/2;
    }
    public void Shoot()
    {
        var _spawnDirection = new Vector2(transform.position.x + 4, transform.position.y);
        var _bullet = Instantiate(Bullet, _spawnDirection, Quaternion.identity) as Rigidbody2D;
        _bullet.AddForce(new Vector2(SpeedOfBullet, 0));
        HasBullet = false;
        HasBulletText.text = "";
    }

	public int HitPoints{
		set{
            if (IsShieldOn) return;
			hitPoints = value;
			if(hitPoints <= 0){
                GameOver();
			}
		}
		get{
			return hitPoints;
		}
	}

    public float ShieldTimeoutLength;

    internal void Shield()
    {
        IsShieldOn = true;
        HasShield = false;

        ForceField.SetActive(true);
        StartCoroutine("ShieldTimeout");

        HasShieldText.text = "";
    }

    private IEnumerator ShieldTimeout()
    {
        yield return new WaitForSeconds(ShieldTimeoutLength);
        IsShieldOn = false;
        ForceField.SetActive(false);
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
        GameController.GameOver();
    }

    public void StartNewGame()
    {
        transform.position = new Vector3(transform.position.x, _startY, 0f);
        gameObject.SetActive(true);
        AntiGravitationForce = BaseAntiGravitation;
        GravitationForce = 0;
    }
}
