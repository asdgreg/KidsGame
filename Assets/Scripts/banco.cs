using UnityEngine;
using System.Collections;

public class banco : MonoBehaviour {

	public int deuda;
	public int dinero;
	public GameObject datob;
	public datos dat;
	public TextMesh dineroac;
	public TextMesh deudaac;
	public AudioSource tienep;
	public AudioSource mastarde;
	public AudioSource aceptado;
	public bool prestamosacado = false;

	// Use this for initialization
	void Start () {
		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		deuda = dat.deuda;
		dinero = dat.dinero;
	}
	
	// Update is called once per frame
	void Update () {
		dineroac.text = "DINERO: "+  dinero.ToString();
		deudaac.text = "DEUDA: " +deuda.ToString();
	}
	
	public void btn1(){
		if (deuda == 0) {
			NotificationCenter.DefaultCenter ().PostNotification (this, "incrementodeuda", 110);
			NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 100);
			deuda = 110;
			prestamosacado = true;
			aceptado.Play();
		} else {
			Debug.Log("Aun debe");
			tienep.Play();
		}
	}
	public void btn2(){
		if (deuda == 0) {
			Debug.Log ("prestamo permitido");
			NotificationCenter.DefaultCenter ().PostNotification (this, "incrementodeuda", 550);
			NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 500);
			deuda = 550;
			prestamosacado = true;
			aceptado.Play();
		} else {
			Debug.Log("Aun debe");
			tienep.Play();
		}
	}
	public void btn3(){
		if (deuda == 0) {
			Debug.Log ("prestamo permitido");
			NotificationCenter.DefaultCenter ().PostNotification (this, "incrementodeuda",2200);
			NotificationCenter.DefaultCenter ().PostNotification (this, "incrementarDinero", 2000);
			deuda = 2200;
			prestamosacado = true;
			aceptado.Play();
		} else {
			Debug.Log("Aun debe");
			tienep.Play();
		}
	}
	
	public void inicio(){
		if (!prestamosacado) {
			StartCoroutine (source ());
		}
		else {
			Application.LoadLevel ("Inicio");
		}
	}

	IEnumerator source(){
		mastarde.Play ();
		yield return new WaitForSeconds (2f);
		Application.LoadLevel ("Inicio");
	}

}
