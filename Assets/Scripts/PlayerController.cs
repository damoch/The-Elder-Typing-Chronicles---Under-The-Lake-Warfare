using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	Vector2 movement;
	public float smooth = 0.4f;

	public float goodKeyPower = 1f;
	public float badKeyPower = 1f;
	public float noKeyPower = 0.5f;

	
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
	}

	void GoodKey(){
		movement += Vector2.down * goodKeyPower;
	}
	void BadKey(){
		movement += Vector2.up * badKeyPower;
	}

}
