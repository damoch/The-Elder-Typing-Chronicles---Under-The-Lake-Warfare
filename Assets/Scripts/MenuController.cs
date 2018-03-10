using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject x;

	public void StartGame(){
		SceneManager.LoadScene(1);
	}

	public void MagicznaMetodaDoTogglowaniaCreditsów(){
		x.SetActive(!x.activeSelf); 
	}
}
