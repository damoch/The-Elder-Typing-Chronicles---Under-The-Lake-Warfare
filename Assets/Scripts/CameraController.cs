using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	float newRotation = 3;
	bool isShaking = false;
	float shakeTime;
	float shakeForce;
	void Start () {
	}

	void Update () {
		if(isShaking)
			transform.rotation = Quaternion.Euler(0,0,Random.Range(-shakeForce, shakeForce));
		else 
			transform.rotation = Quaternion.Euler(0,0,0);
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
