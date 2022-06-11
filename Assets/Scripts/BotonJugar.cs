using UnityEngine;
using System.Collections;

public class BotonJugar : MonoBehaviour {

	public string nivelACargar = "Inicio";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//Camera.main.GetComponent<AudioSource>().Stop ();
		GetComponent<AudioSource> ().Play ();
		Application.LoadLevel (nivelACargar);
		//Invoke ("CargarNivelJuego", GetComponent<AudioSource>().clip.length);
	}
	void CargarNivelJuego(){
		//Application.LoadLevel("GameScene");
	}
}
