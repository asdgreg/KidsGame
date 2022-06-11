using UnityEngine;
using System.Collections;
using System;
public class ActivarGameOver : MonoBehaviour {
	public GameObject datob;
	public datos dat;
	public int deuda;
	public int dinero;
	int te = 0;

	public int ganado;
	public int ingreso;
	public int pago;
	public GameObject camaraGameOver;
	public TextMesh puntuacion;
	 public AudioSource ganaste;
	public AudioSource debesmenos;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "TerminarJuego");
		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		deuda = dat.deuda;
		dinero = dat.dinero;

	}
	void TerminarJuego(){
		GetComponent<AudioSource>().Stop ();
		camaraGameOver.SetActive (true);
		NotificationCenter.DefaultCenter ().PostNotification (this, "Puntos", puntuacion.text);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator gano(){
//		ganado =  Convert.ToInt32(puntuacion.text.Substring (2));
//		print ("asdasdasdasd " + puntuacion.text.Substring (2));
//		ingreso = Convert.ToInt32((ganado / 2));
//		puntuacion.text = pago.ToString();
//		NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", ingreso);
//		ganaste.Play();
yield return new WaitForSeconds (1f);
//		if (deuda > 0) {
//			debesmenos.Play ();
//			NotificationCenter.DefaultCenter ().PostNotification (this, "menosdeuda", pago*0.10);
//		}
//		yield return new WaitForSeconds (1f);
		
	}

	public void inicio(){
		Application.LoadLevel ("Inicio");
		Debug.Log ("asdasd");
	}
}
