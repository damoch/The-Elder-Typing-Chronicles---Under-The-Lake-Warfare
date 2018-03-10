using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	bool isShaking = false;
	float shakeTime;
	float shakeForce;
	void Start () {
	}

	void Update () {
		if(isShaking){
			transform.rotation = Quaternion.Euler(0,0,shakeForce);
			Camera.main.orthographicSize += Mathf.Abs(shakeForce); 
			shakeForce = Mathf.Lerp(shakeForce, -shakeForce - (shakeForce * shakeTime), shakeTime);
		}
		else 
			transform.rotation = Quaternion.Euler(0,0,0);
			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 10f, 0.1f);
	}
 	IEnumerator ShakeTimeOut(){
		isShaking = true;
		yield return new WaitForSeconds(shakeTime);
		isShaking = false;
	}

	public void Shake(float shakeTime, float shakeForce){
		this.shakeTime = shakeTime;
		this.shakeForce = shakeForce;
		StartCoroutine("ShakeTimeOut");

	}
}
