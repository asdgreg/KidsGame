
using UnityEngine;
using System.Collections;

public class controlesExtras : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void seleccionnino(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "dpersonaje", 2);
		PlayerPrefs.SetInt("personaje",2);
		Application.LoadLevel("1_nino");
	}
	public void seleccionnina(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "dpersonaje", 1);
		PlayerPrefs.SetInt ("personaje",1);
		Application.LoadLevel ("1_nina");
	}
	public void seleccionmascota(){
		Debug.Log("Camara  Inicio");

		Application.LoadLevel("desicionmascota");
	}
	public void gatoInicio(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "dmascota", 1);
		PlayerPrefs.SetInt("primer", 1);
		PlayerPrefs.SetInt("mascota",1);
		Application.LoadLevel("Inicio");
	}
	public void perroInicio(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "dmascota", 2);
		PlayerPrefs.SetInt("primer", 1);
		PlayerPrefs.SetInt("mascota",2);
		Application.LoadLevel("Inicio");

	}
	
	public void edadmenor(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "poneredad", 4);
		PlayerPrefs.SetInt ("edad", 4);
		Application.LoadLevel ("desicionsexo");
	}
	public void edadmayor(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "poneredad", 9);
		PlayerPrefs.SetInt ("edad", 7);
		Application.LoadLevel ("desicionsexo");
	}



}
