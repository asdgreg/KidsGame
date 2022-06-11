using UnityEngine;
using System.Collections;

public class tienda : MonoBehaviour {
	public int deuda;
	public int dinero;
	public GameObject datob;
	public datos dat;

	public AudioSource conceptoprestamo;
	public AudioSource comprado;
	public AudioSource nomascota;


	// Use this for initialization
	void Start () {
		datob = GameObject.FindGameObjectWithTag("Datos");
		dat = datob.GetComponent<datos> ();
		deuda = dat.deuda;
		dinero = dat.dinero;
	}
	
	// Update is called once per frame
	void Update () {
		dinero = dat.dinero;
	}
	public void hueso(){
		if(dinero >= 100){
			if(PlayerPrefs.GetInt("mascota") == 2){Debug.Log ("compra hueso");
				NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",100);
				NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",6);
				comprado.Play ();}else{
				nomascota.Play();
			}
		
		}else{
			conceptoprestamo.Play();
		}

	}
	public void raton(){
		if(dinero >= 100){
			if(PlayerPrefs.GetInt("mascota") == 1){
		Debug.Log ("compra raton");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",100);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",7);
			comprado.Play ();}else{
				nomascota.Play();}
	}else{
		conceptoprestamo.Play();
	}
	}
	public void benera(){
		if(dinero >= 500){

		Debug.Log ("compra banera");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",500);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",9);
		comprado.Play ();
}else{
	conceptoprestamo.Play();
}
	}
	public void botella(){
		if(dinero >= 10){
		Debug.Log ("compra botella");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",10);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",8);
		comprado.Play ();
}else{
	conceptoprestamo.Play();
}
	}
	public void casag(){
		if(dinero >= 2500){
			if(PlayerPrefs.GetInt("mascota") == 1){
		Debug.Log ("compra casag");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",2500);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",1);
			comprado.Play ();}else{
				nomascota.Play();}
}else{
	conceptoprestamo.Play();
}
	}
	public void casap(){
		if(dinero >= 2000){
			if(PlayerPrefs.GetInt("mascota") == 2){
		Debug.Log ("compra casap");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto", 2000);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",0);
			comprado.Play ();}else{
				nomascota.Play();}
}else{
	conceptoprestamo.Play();
}
	}
	public void cepillo(){
		if(dinero >= 20){
		Debug.Log ("compra cepillo");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",20);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",2);
		comprado.Play ();
}else{
	conceptoprestamo.Play();
}
	}
	public void collarg(){
		if(dinero >= 50){
			if(PlayerPrefs.GetInt("mascota") == 1){
		Debug.Log ("compra collarg");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",50);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",13);
			comprado.Play ();}else{
				nomascota.Play();}
}else{
	conceptoprestamo.Play();
}
	}
	public void collarp(){
		if(dinero >= 50){
			if(PlayerPrefs.GetInt("mascota") == 2){
		Debug.Log ("compra collarp");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",50);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",12);
			comprado.Play ();}else{
				nomascota.Play();}
}else{
	conceptoprestamo.Play();
}
	}
	public void comidag(){
		if(dinero >= 100){
			if(PlayerPrefs.GetInt("mascota") ==1){
		Debug.Log ("compra comidag");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",100);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",4);
			comprado.Play ();}else{
				nomascota.Play();}
}else{
	conceptoprestamo.Play();
}
	}
	public void comidap(){
		if(dinero >= 100){
			if(PlayerPrefs.GetInt("mascota") == 2){
		Debug.Log ("compra comidap");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",100);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",3);
			comprado.Play ();}else{
				nomascota.Play();}
}else{
	conceptoprestamo.Play();
}
	}
	public void shampoo(){
		if(dinero >= 70){
		Debug.Log ("compra shampoo");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",70);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",5);
		comprado.Play ();
}else{
	conceptoprestamo.Play();
}
	}
	public void tazonp(){
		if(dinero >= 300){
			if(PlayerPrefs.GetInt("mascota") == 2){
		Debug.Log ("compra tazonp");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",300);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",10);
			comprado.Play ();}else{
				nomascota.Play();}
}else{
	conceptoprestamo.Play();
}
	}
	public void tazong(){
		if(dinero >= 300){
			if(PlayerPrefs.GetInt("mascota") == 1){
		Debug.Log ("compra tazong");
		NotificationCenter.DefaultCenter ().PostNotification (this, "compraobjeto",300);
		NotificationCenter.DefaultCenter ().PostNotification (this, "comproobjeto",11);
			comprado.Play ();}else{
				nomascota.Play();}
}else{
	conceptoprestamo.Play();
}
	}
	public void inicio(){
		Application.LoadLevel("Inicio");
	}
}
