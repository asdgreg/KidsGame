﻿using UnityEngine;
using System.Collections;

public class GeneradorAtrapa : MonoBehaviour {

	public GameObject[] objetos;
	public float tiempoMin = 1f;
	public float tiempoMax = 1.5f;
	public bool seguir = true;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "EmpiezaGenerar");
		NotificationCenter.DefaultCenter ().AddObserver (this, "TerminarJuego");
	}

	void EmpiezaGenerar(Notification notificacion){
		//Debug.Log("entro generador");
		Generar ();
	}
	void TerminarJuego(Notification notificacion){
		seguir = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Generar(){
		if (seguir) {
			Instantiate(objetos[Random.Range(0,objetos.Length)], transform.position, Quaternion.identity);
			Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
		}
	}
}
