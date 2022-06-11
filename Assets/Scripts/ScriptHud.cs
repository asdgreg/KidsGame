using UnityEngine;
using System.Collections;
using System;

public class ScriptHud : MonoBehaviour {

	public GameObject datob;
	public datos dat;
	public int deuda;
	public int dinero;

	public bool pago = true;

	public TextMesh puntuacion;
	public TextMesh punpantalla;

	public GameObject cronometro;
	public GameObject jugador;

	public int puntuacionTotal = 0;
	public int numeroIntentos = 3;

	public AudioClip audioGameOver;
	public float volumenClip = 0.5f;
	public AudioSource ganaste;
	public AudioSource debesmenos;
	// Use this for initialization
	void Start () {
		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		deuda = dat.deuda;
		dinero = dat.dinero;

		NotificationCenter.DefaultCenter().PostNotification(this, "EmpiezaGenerar");
		NotificationCenter.DefaultCenter ().AddObserver (this, "DisminuyeIntento");
		NotificationCenter.DefaultCenter ().AddObserver (this, "AumentarPuntuacion");
		NotificationCenter.DefaultCenter ().AddObserver (this, "TerminarJuego");
	}

//	void DisminuyeIntento(Notification notificacion){
//		if (numeroIntentos > 1) {
//			numeroIntentos -= 1;
//			string texto = "";
//			for (int i = 0; i < 3; i++) {
//				if (i < numeroIntentos) {
//					texto += "o";
//				} else
//					texto += "x";
//			}
//			intentos.text = texto;
//		} else 
//			if (numeroIntentos == 1){
//				intentos.text = "xxx";
//				NotificationCenter.DefaultCenter().PostNotification(this, "TerminarJuego");
//				TerminarJuego();
//			}
//	}
	void AumentarPuntuacion(Notification notificacion){
		int puntos = (int)notificacion.data;
		puntuacionTotal += puntos;
		puntuacion.text = "PC " + puntuacionTotal.ToString();
	}
	void TerminarJuego(){
		GetComponent<AudioSource>().Stop ();
	 	AudioSource.PlayClipAtPoint(audioGameOver, Camera.main.transform.position, volumenClip);
		jugador.SetActive (false);
		cronometro.SetActive(false);
		if (pago) {
			pago = false;
			StartCoroutine (gano ());
		}
	}

	public IEnumerator gano(){
		int total = puntuacionTotal / 2;
		punpantalla.text = total.ToString();
		int totaldisminuye = total / 2;
		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", total);
		NotificationCenter.DefaultCenter ().PostNotification (this, "menosdeuda", totaldisminuye);
		ganaste.Play();
		yield return new WaitForSeconds (1f);
		if (deuda > 0) {
			debesmenos.Play ();

		}
		yield return new WaitForSeconds (1f);
		
	}
	// Update is called once per frame
	void Update () {
	}
}
