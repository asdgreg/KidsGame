using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class menuBotones : MonoBehaviour {
	public GUIStyle estilo;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}


	public void iniciar(){

		if (PlayerPrefs.GetInt("primer") == 0 ) {
			Debug.Log ("Camara  Inicio");
			Application.LoadLevel ("desicionedad");
		} else {
			Application.LoadLevel ("Inicio");
		}
	}

	public void salir(){
		Debug.Log("Camara  Salir");
		Application.Quit();
	}
	
}
